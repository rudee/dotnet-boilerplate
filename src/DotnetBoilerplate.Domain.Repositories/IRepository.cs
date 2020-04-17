using System.Threading;
using System.Threading.Tasks;

namespace DotnetBoilerplate.Domain.Repositories
{
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity>
        where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity           entity,
                               CancellationToken cancellationToken = default);

        Task RemoveAsync(TEntity           entity,
                         CancellationToken cancellationToken = default);

        Task<TEntity> UpdateAsync(TEntity           entity,
                                  CancellationToken cancellationToken = default);
    }
}
