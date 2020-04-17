using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using DotnetBoilerplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DotnetBoilerplate.Infrastructure.Repositories.EntityFrameworkCore
{
    public abstract class ReadOnlyRepositoryBase<TEntity> : IReadOnlyRepository<TEntity>
        where TEntity : class
    {
        protected virtual DbContext Context { get; private set; }

        public ReadOnlyRepositoryBase(DbContext context)
        {
            Context = context;
        }

        public virtual IQueryable<TEntity> AsQueryable()
        {
            return Context.Set<TEntity>().AsQueryable();
        }

        public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate,
                                                     CancellationToken               cancellationToken = default)
        {
            return await Context.Set<TEntity>()
                .SingleOrDefaultAsync(predicate, cancellationToken)
                .ConfigureAwait(false);
        }

        public virtual async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate,
                                                                     CancellationToken               cancellationToken = default)
        {
            return await Context.Set<TEntity>()
                .Where(predicate)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
