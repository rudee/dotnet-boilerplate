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
    public class ReadOnlyRepository<TDbContext, TEntity, TPrimaryKey, TUserId> :
        IReadOnlyRepository<TEntity, TPrimaryKey, TUserId>
        where TDbContext  : DbContext
        where TEntity     : class, IEntity<TPrimaryKey, TUserId>
        where TPrimaryKey : struct
        where TUserId     : struct
    {
        protected virtual TDbContext Context { get; private set; }

        public ReadOnlyRepository(TDbContext context)
        {
            Context = context;
        }

        public virtual async Task<TEntity> GetAsync(TPrimaryKey                        id,
                                                    Expression<Func<TEntity, TEntity>> selector          = null,
                                                    CancellationToken                  cancellationToken = default)
        {
            IQueryable<TEntity> q = Context.Set<TEntity>();

            q = ApplyFilter(q);

            q = q.Where(e => e.Id.Equals(id));

            if (selector != null)
            {
                q = q.Select(selector);
            }

            return await q
                .SingleOrDefaultAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>    predicate         = null,
                                                                    Expression<Func<TEntity, TEntity>> selector          = null,
                                                                    CancellationToken                  cancellationToken = default)
        {
            IQueryable<TEntity> q = Context.Set<TEntity>();

            q = ApplyFilter(q);

            if (predicate != null)
            {
                q = q.Where(predicate);
            }

            if (selector != null)
            {
                q = q.Select(selector);
            }

            return await q
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public virtual async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>>    predicate         = null,
                                                                Expression<Func<TEntity, TEntity>> selector          = null,
                                                                CancellationToken                  cancellationToken = default)
        {
            IQueryable<TEntity> q = Context.Set<TEntity>();

            q = ApplyFilter(q);

            if (predicate != null)
            {
                q = q.Where(predicate);
            }

            if (selector != null)
            {
                q = q.Select(selector);
            }

            return await q
                .SingleOrDefaultAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>>    predicate         = null,
                                                               Expression<Func<TEntity, TEntity>> selector          = null,
                                                               CancellationToken                  cancellationToken = default)
        {
            IQueryable<TEntity> q = Context.Set<TEntity>();

            q = ApplyFilter(q);

            if (predicate != null)
            {
                q = q.Where(predicate);
            }

            if (selector != null)
            {
                q = q.Select(selector);
            }

            return await q
                .FirstOrDefaultAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public virtual IQueryable<TEntity> AsQueryable()
        {
            IQueryable<TEntity> q = Context.Set<TEntity>();

            return ApplyFilter(q);
        }



        private static IQueryable<TEntity> ApplyFilter(IQueryable<TEntity> q)
        {
            if (typeof(ISoftDelete).IsAssignableFrom(typeof(TEntity)))
            {
                q = q.Where(e => !((ISoftDelete)e).IsDeleted);
            }

            return q;
        }
    }
}
