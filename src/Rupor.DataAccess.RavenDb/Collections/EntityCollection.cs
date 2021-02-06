using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Raven.Client.Documents;
using Raven.Client.Documents.Operations.OngoingTasks;
using Raven.Client.Documents.Session;
using Rupor.DataAccess.Collections;

namespace Rupor.DataAccess.RavenDb.Collections
{
    public class EntityCollection<T> : IEntityCollection<T> where T : class
    {
        protected IAsyncDocumentSession AsyncSession { get; }
        protected IDocumentSession Session { get; }

        public Task AddAsync(T entity, CancellationToken token = default)
        {
            if (Session != null)
            {
                return Task.Run(() => Session.Store(entity), token);
            }

            return AsyncSession.StoreAsync(entity, token);
        }

        public void Add(T entity)
        {
            Session.Store(entity);
        }

        public Task<T> LoadAsync(string id, CancellationToken token = default)
            => AsyncSession.LoadAsync<T>(id, token);
        

        public Task DeleteAsync(string id, CancellationToken token = default)
            => Task.Run(() => { Session.Delete(id); }, token);


        public Task DeleteAsync(ICollection<string> identifiers, CancellationToken token = default)
            => Task.Run(() =>
            {
                foreach (var id in identifiers)
                {
                    Session.Delete(id);
                }
            }, token);


        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression, CancellationToken token = default)
            => AsyncSession.Query<T>().FirstOrDefaultAsync(expression, token);


        public Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> expression, CancellationToken token = default)
            => AsyncSession.Query<T>().SingleOrDefaultAsync(expression, token);


        public Task<IQueryable<T>> WhereAsync(Expression<Func<T, bool>> expression, CancellationToken token = default)
            => Task.Run(() => AsyncSession.Query<T>().Where(expression), token);
    }
}