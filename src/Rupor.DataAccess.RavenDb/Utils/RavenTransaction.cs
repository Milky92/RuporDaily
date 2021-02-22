using Raven.Client.Documents;
using Rupor.DataAccess.RavenDb.Context;
using System;
using System.Transactions;

namespace Rupor.DataAccess.RavenDb.Utils
{
    public class RavenTransaction :  IDisposable
    {
        private readonly TransactionScope _transactionScope;
        internal IDocumentStore DocumentStore { get; }

        public RavenTransaction(IDocumentStore documentStore)
        {
            _transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Suppress);
            DocumentStore = documentStore;
        }

        internal static RavenTransaction Create(IDocumentStore store)
            => new RavenTransaction(store);

        public void Commit()
            => _transactionScope.Complete();

        public T BeginSession<T>() where T : RavenDbContext
            => (T)Activator.CreateInstance(typeof(T), this);

        public void Dispose()
            => _transactionScope?.Dispose();

        public void Begin()
        {
            BeginSession<RavenDbContext>();
        }        
    }
}