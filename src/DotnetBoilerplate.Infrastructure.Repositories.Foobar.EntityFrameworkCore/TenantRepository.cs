using DotnetBoilerplate.Domain.Entities.Foobar;
using DotnetBoilerplate.Domain.Repositories.Foobar;
using DotnetBoilerplate.Infrastructure.Repositories.EntityFrameworkCore;

namespace DotnetBoilerplate.Infrastructure.Repositories.Foobar.EntityFrameworkCore
{
    public class TenantRepository : RepositoryBase<Tenant>, ITenantRepository
    {
        public TenantRepository(ExampleDbContext context)
            : base(context)
        {
        }
    }
}
