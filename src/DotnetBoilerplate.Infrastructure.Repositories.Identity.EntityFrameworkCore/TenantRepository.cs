using DotnetBoilerplate.Domain.Entities.Identity;
using DotnetBoilerplate.Domain.Repositories.Identity;
using DotnetBoilerplate.Infrastructure.RepositoriesBase.EntityFrameworkCore;

namespace DotnetBoilerplate.Infrastructure.Repositories.Identity.EntityFrameworkCore
{
    public class TenantRepository : RepositoryBase<Tenant>, ITenantRepository
    {
        public TenantRepository(IdentityDbContext context)
            : base(context)
        {
        }
    }
}
