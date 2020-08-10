using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Dnb.Domain.Entities;
using Dnb.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Dnb.Infrastructure.RepositoriesBase.EFCore
{
    public class Repository<TDbContext, TEntity, TPrimaryKey, TUserId> :
        ReadOnlyRepository<TDbContext, TEntity, TPrimaryKey, TUserId>,
        IRepository<TEntity, TPrimaryKey, TUserId>
        where TDbContext  : DbContext
        where TEntity     : class, IEntity<TPrimaryKey, TUserId>
        where TPrimaryKey : struct
        where TUserId     : struct
    {
        public Repository(TDbContext context)
            : base(context)
        {
        }

        public virtual async Task<TEntity> AddAsync(TEntity           entity,
                                                    CancellationToken cancellationToken = default)
        {
            await DbSet
                .AddAsync(entity, cancellationToken)
                .ConfigureAwait(false);

            await Context.SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> AddAsync(IEnumerable<TEntity> entities,
                                                                 CancellationToken    cancellationToken = default)
        {
            await DbSet.AddRangeAsync(entities, cancellationToken);

            await Context.SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            return entities;
        }

        public virtual async Task DeleteAsync(TPrimaryKey       id,
                                              CancellationToken cancellationToken = default)
        {
            TEntity entity = DbSet.Single(db => db.Id.Equals(id));

            if (typeof(ISoftDelete).IsAssignableFrom(typeof(TEntity)))
            {
                ((ISoftDelete)entity).IsDeleted = true;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }

            await Context.SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public virtual async Task DeleteAsync(IEnumerable<TPrimaryKey> ids,
                                              CancellationToken        cancellationToken = default)
        {
            IQueryable<TEntity> entities = DbSet.Where(db => ids.Contains(db.Id));

            DbSet.RemoveRange(entities);

            await Context.SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public virtual async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate,
                                              CancellationToken               cancellationToken = default)
        {
            IQueryable<TEntity> entities = DbSet.Where(predicate);

            DbSet.RemoveRange(entities);

            await Context.SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity           entity,
                                                       CancellationToken cancellationToken = default)
        {
            DbSet.Attach(entity);

            Context.Entry(entity).State = EntityState.Modified;

            await Context.SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> UpdateAsync(IEnumerable<TEntity> entities,
                                                                    CancellationToken    cancellationToken = default)
        {
            DbSet.UpdateRange(entities);

            await Context.SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            return entities;
        }
    }
}
