using DotnetBoilerplate.Domain.Entities.Identity;
using DotnetBoilerplate.Domain.RepositoriesBase;

namespace DotnetBoilerplate.Domain.Repositories.Identity
{
    public interface ITenantRepository : IRepository<Tenant>
    {
    }
}
