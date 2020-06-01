using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dnb.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Dnb.Infrastructure.RepositoriesBase.EFCore
{
    /*
    public abstract class RepositoryBase<TEntity, TPrimaryKey> : ReadOnlyRepository<TEntity, TPrimaryKey>, IRepository<TEntity, TPrimaryKey>
        where TEntity     : class
        where TPrimaryKey : struct
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
                .ConfigureAwait(false);

            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> AddManyAsync(IEnumerable<TEntity> entities,
                                                                     CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task RemoveAsync(TEntity           entity,
                                              CancellationToken cancellationToken = default)
        {
            Context.Set<TEntity>().Attach(entity);
            Context.Set<TEntity>().Remove(entity);

            await Context.SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public virtual async Task<IEnumerable<TEntity>> RemoveManyAsync(IEnumerable<TEntity> entities,
                                                                        CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
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

        public virtual async Task<IEnumerable<TEntity>> UpdateManyAsync(IEnumerable<TEntity> entities,
                                                                        CancellationToken    cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
    */
}
