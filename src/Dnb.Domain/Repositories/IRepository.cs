using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Dnb.Domain.Entities;

namespace Dnb.Domain.Repositories
{
    public interface IRepository<TEntity, TPrimaryKey, TUserId> :
        IReadOnlyRepository<TEntity, TPrimaryKey, TUserId>
        where TEntity     : class, IEntity<TPrimaryKey, TUserId>
        where TPrimaryKey : struct
        where TUserId     : struct
    {
        Task<TEntity> AddAsync(TEntity           entity,
                               CancellationToken cancellationToken = default);
        Task<TPrimaryKey> AddAndGetIdAsync(TEntity          entity,
                                           CancellationToken cancellationToken = default);

        Task DeleteAsync(TEntity           entity,
                         CancellationToken cancellationToken = default);

        Task DeleteAsync(TPrimaryKey       id,
                         CancellationToken cancellationToken = default);

        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate,
                         CancellationToken               cancellationToken = default);

        Task<TEntity> UpdateAsync(TEntity           entity,
                                  CancellationToken cancellationToken = default);
    }
}
