using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Dnb.Infrastructure.RepositoriesBase.EFCore
{
    public class UnitOfWork<TDbContext>
        where TDbContext : DbContext
    {
        private TDbContext _context;

        private UnitOfWork(TDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public static UnitOfWork<TDbContext> New(TDbContext context) => new UnitOfWork<TDbContext>(context);

        public async Task ExecuteAsync(Func<Task> action)
        {
            var strategy = _context.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
                {
                    await action();

                    transaction.Commit();
                }
            });
        }
    }
}
