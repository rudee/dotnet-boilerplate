using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotnetBoilerplate.Domain.RepositoriesBase
{
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity>
        where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity           entity,
                               CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> AddManyAsync(IEnumerable<TEntity> entities,
                                                CancellationToken    cancellationToken = default);

        Task RemoveAsync(TEntity           entity,
                         CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> RemoveManyAsync(IEnumerable<TEntity> entities,
                                                   CancellationToken    cancellationToken = default);

        Task<TEntity> UpdateAsync(TEntity           entity,
                                  CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> UpdateManyAsync(IEnumerable<TEntity> entities,
                                                   CancellationToken    cancellationToken = default);
    }
}
