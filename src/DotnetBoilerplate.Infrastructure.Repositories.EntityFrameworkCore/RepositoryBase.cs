using System.Threading;
using System.Threading.Tasks;
using DotnetBoilerplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DotnetBoilerplate.Infrastructure.Repositories.EntityFrameworkCore
{
    public abstract class RepositoryBase<TEntity> : ReadOnlyRepositoryBase<TEntity>, IRepository<TEntity>
        where TEntity : class
    {
        protected new DbContext Context { get; private set; }

        public RepositoryBase(DbContext context)
            : base(context)
        {
            Context = context;
        }

        public virtual async Task<TEntity> AddAsync(TEntity           entity,
                                                    CancellationToken cancellationToken = default)
        {
            await Context.Set<TEntity>()
                .AddAsync(entity, cancellationToken)
                .ConfigureAwait(false);

            await Context.SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false); ;

            return entity;
        }

        public virtual async Task RemoveAsync(TEntity           entity,
                                              CancellationToken cancellationToken = default)
        {
            Context.Set<TEntity>().Attach(entity);
            Context.Set<TEntity>().Remove(entity);

            await Context.SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity           entity,
                                                       CancellationToken cancellationToken = default)
        {
            Context.Set<TEntity>().Attach(entity);

            Context.Entry(entity).State = EntityState.Modified;

            await Context.SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            return entity;
        }
    }
}
