using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using Raven.Client.Documents.Changes;
using Raven.Client.Documents.Session;
using Rupor.DataAccess.RavenDb.Settings;
using Rupor.DataAccess.RavenDb.Utils;
using Raven.Client.Documents;
using System.Linq;
using Raven.Client;
using Rupor.DataAccess.RavenDb.Collections;

namespace Rupor.DataAccess.RavenDb.Context
{
    public class RavenDbContext : IDisposable
    {
        private bool disposed = false;

        private readonly DatabaseOptions _dbOptions;
        private readonly IAsyncDocumentSession _asyncSession;
        private readonly RavenDatabase _db;
       
        //#region collections

        ////public IEntityCollection<Topic> Topics { get; set; }

        //#endregion
       
        protected RavenDbContext(IServiceProvider serviceProvider,IOptions<DatabaseOptions> options)
        {
            _dbOptions = options.Value;
            _db = serviceProvider.GetService<RavenDatabase>() ?? throw new ArgumentNullException(nameof(serviceProvider));
            _asyncSession = _db.IntializeAsync(this).GetAwaiter().GetResult();
            InitCollections();
        }

        protected RavenDbContext(RavenTransaction transaction)
        {
            _asyncSession = transaction.DocumentStore.OpenAsyncSession();
            InitCollections();
        }

        public RavenTransaction BeginTransaction()
            => _db.BeginTransaction();

        public Task SaveChangesAsync(CancellationToken token = default)
        => _asyncSession.SaveChangesAsync(token);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;

            if (disposing)
            {
                _asyncSession.Dispose();
            }

            disposed = true;
        }

        private void InitCollections()
        {
            var collections = GetType().GetProperties()
                  .Where(p => p.PropertyType.IsGenericType &&
                            p.PropertyType.GetGenericTypeDefinition() == typeof(EntityCollection<>)
                  )
                  .ToList();

             collections.ForEach(p => p.SetValue(this, Activator.CreateInstance(p.PropertyType, _asyncSession)));

        }

    }
}