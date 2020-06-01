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

        public virtual async Task<TEntity> GetAsync(TPrimaryKey       id,
                                                    CancellationToken cancellationToken = default)
        {
            return await Context.Set<TEntity>()
                .FindAsync(new object[] { id }, cancellationToken)
                .ConfigureAwait(false);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate         = null,
                                                                    CancellationToken               cancellationToken = default)
        {
            IQueryable<TEntity> q = Context.Set<TEntity>();

            if (predicate == null)
            {
                return await q
                    .ToListAsync(cancellationToken)
                    .ConfigureAwait(false);
            }

            return await q
                .Where(predicate)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public virtual async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate,
                                                                CancellationToken               cancellationToken = default)
        {
            IQueryable<TEntity> q = Context.Set<TEntity>();

            return await q
                .SingleOrDefaultAsync(predicate, cancellationToken)
                .ConfigureAwait(false);
        }

        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate,
                                                               CancellationToken               cancellationToken = default)
        {
            IQueryable<TEntity> q = Context.Set<TEntity>();

            return await q
                .FirstOrDefaultAsync(predicate, cancellationToken)
                .ConfigureAwait(false);
        }

        public virtual IQueryable<TEntity> AsQueryable()
        {
            return Context.Set<TEntity>().AsQueryable();
        }






        /*
        public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate,
                                                     CancellationToken               cancellationToken = default)
        {
            return await Context.Set<TEntity>()
                .SingleOrDefaultAsync(predicate, cancellationToken)
                .ConfigureAwait(false);
        }

        public virtual async Task<IEnumerable<TEntity>> FindManyAsync(Expression<Func<TEntity, bool>> predicate,
                                                                      CancellationToken               cancellationToken = default)
        {
            return await Context.Set<TEntity>()
                .Where(predicate)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }
        */




        /*
        public virtual IQueryable<TEntity> AsQueryable(params NavigationPropertyTree<TEntity>[] includeNavigationTrees)
        {
            IQueryable<TEntity> q = Context.Set<TEntity>().AsQueryable();

            q = Include(q, includeNavigationTrees);

            return q;
        }
        */

        /*
        public virtual IQueryable<TEntity> AsQueryable(params NavigationPropertyTree<TEntity>[] includeNavigationTrees)
        {
            IQueryable<TEntity> q = Context.Set<TEntity>().AsQueryable();

            q = Include(q, includeNavigationTrees);

            return q;
        }
        */

        /*
        private IQueryable<TEntity> Include(IQueryable<TEntity> q,
                                            NavigationPropertyTree<TEntity>[] includeNavigationTrees)
        {
            if (includeNavigationTrees == null)
            {
                return q;
            }

            foreach (NavigationPropertyTree<TEntity> t in includeNavigationTrees)
            {
                if (t == null)
                {
                    continue;
                }

                t.Path
                //q.Include()
            }

            return q;
        }
        */

        //private IIncludableQueryable<TEntity, TProperty> Include<TEntity, TProperty>(IQueryable<TEntity>             source,
        //                                                                             NavigationPropertyPath<TEntity> navigationPropertyPath)
        //    //where TProperty : class
        //{
        //    return source.Include((Expression<Func<TEntity, TProperty>>)navigationPropertyPath.Path);

        //    //source.Include(includeNavigationPropertyPath.Path);
        //}
    }
}
