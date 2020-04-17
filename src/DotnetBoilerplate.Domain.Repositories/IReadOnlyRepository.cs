using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace DotnetBoilerplate.Domain.Repositories
{
    public interface IReadOnlyRepository<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> AsQueryable();

        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate,
                                CancellationToken               cancellationToken = default);

        Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate = null,
                                                CancellationToken               cancellationToken = default);
    }
}
