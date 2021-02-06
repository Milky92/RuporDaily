using System;
using System.Threading;
using System.Threading.Tasks;
using Raven.Client.Documents.Changes;
using Rupor.DataAccess.Collections;
using Rupor.DataAccess.Context;
using Rupor.Domain.Models;

namespace Rupor.DataAccess.RavenDb.Context
{
    public class RaveDbContext: IDatabaseContext
    {
        private bool disposed = false;

        public IEntityCollection<Topics> Topics { get; set; }
        
        public Task SaveChangesAsync(CancellationToken token = default)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        public async ValueTask DisposeAsync()
        {
            throw new System.NotImplementedException();
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if(disposed) return;

            if (disposing)
            {
                //session.dispose()
            }

            disposed = true;
        }
    }
}