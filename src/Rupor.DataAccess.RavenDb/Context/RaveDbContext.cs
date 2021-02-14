using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using Raven.Client.Documents.Changes;
using Raven.Client.Documents.Session;
using Rupor.DataAccess.Collections;
using Rupor.DataAccess.Context;
using Rupor.DataAccess.RavenDb.Settings;
using Rupor.DataAccess.RavenDb.Utils;
using Rupor.Domain.Models;

namespace Rupor.DataAccess.RavenDb.Context
{
    public class RaveDbContext : IDatabaseContext
    {
        private bool disposed = false;

        private readonly DatabaseOptions _dbOptions;
        private readonly IAsyncDocumentSession _asyncSession;
        private readonly RavenDatabase _db;
        #region collections

        public IEntityCollection<Topic> Topics { get; set; }

        #endregion

        protected RaveDbContext(IServiceProvider serviceProvider,IOptions<DatabaseOptions> options)
        {
            _dbOptions = options.Value;
            _db = serviceProvider.GetService<RavenDatabase>() ?? throw new ArgumentNullException(nameof(serviceProvider));
            _asyncSession = _db.IntializeAsync(this).GetAwaiter().GetResult();
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
    }
}