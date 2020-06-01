using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Dnb.Domain.Entities;

namespace Dnb.Domain.Repositories
{
    public interface IReadOnlyRepository<TEntity, TPrimaryKey, TUserId>
        where TEntity     : class, IEntity<TPrimaryKey, TUserId>
        where TPrimaryKey : struct
        where TUserId     : struct
    {
        Task<TEntity> GetAsync(TPrimaryKey       id,
                               CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null,
                                               CancellationToken               cancellationToken = default);

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate,
                                           CancellationToken               cancellationToken = default);

        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate,
                                          CancellationToken               cancellationToken = default);

        IQueryable<TEntity> AsQueryable();
    }
}
