using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Rupor.DataAccess.Collections
{
    public interface IEntityCollection<TEntity> where TEntity : class

    {
        Task AddAsync(TEntity entity, CancellationToken token = default);

        void Add(TEntity entity);

        Task<TEntity> LoadAsync(string id, CancellationToken token = default);

        Task DeleteAsync(string id, CancellationToken token = default);
        
        Task DeleteAsync(ICollection<string> identifiers, CancellationToken token = default);
        
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression,
            CancellationToken token = default);

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> expression,
            CancellationToken token = default);

        Task<IQueryable<TEntity>> WhereAsync(Expression<Func<TEntity,bool>> expression, CancellationToken token = default);
    }
}