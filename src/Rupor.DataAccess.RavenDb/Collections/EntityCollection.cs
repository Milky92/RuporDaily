using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Raven.Client.Documents;
using Raven.Client.Documents.Operations.OngoingTasks;
using Raven.Client.Documents.Session;


namespace Rupor.DataAccess.RavenDb.Collections
{
    public class EntityCollection<T>
    {
        private readonly IAsyncDocumentSession _asyncSession;

        public EntityCollection(IAsyncDocumentSession asyncSession)
        {
            _asyncSession = asyncSession;
        }

        public Task AddAsync(T entity, CancellationToken token = default)
        {

            return _asyncSession.StoreAsync(entity, token);
        }


        public IQueryable<T> Query() => _asyncSession.Query<T>();

        public Task<T> LoadAsync(string id, CancellationToken token = default)
            => _asyncSession.LoadAsync<T>(id, token);


        public Task DeleteAsync(string id, CancellationToken token = default)
            => Task.Run(() => { _asyncSession.Delete(id); }, token);

        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression, CancellationToken token = default)
            => _asyncSession.Query<T>().FirstOrDefaultAsync(expression, token);


        public Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> expression, CancellationToken token = default)
            => _asyncSession.Query<T>().SingleOrDefaultAsync(expression, token);


        public Task<IQueryable<T>> WhereAsync(Expression<Func<T, bool>> expression, CancellationToken token = default)
            => Task.Run(() => _asyncSession.Query<T>().Where(expression), token);
    }
}