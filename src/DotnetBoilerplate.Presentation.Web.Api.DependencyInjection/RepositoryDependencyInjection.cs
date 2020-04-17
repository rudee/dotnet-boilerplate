using DotnetBoilerplate.Domain.Repositories.Foobar;
using DotnetBoilerplate.Infrastructure.Repositories.Foobar.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetBoilerplate.Presentation.Web.Api.DependencyInjection
{
    internal class RepositoryDependencyInjection
    {
        private readonly IServiceCollection _services;

        internal RepositoryDependencyInjection(IServiceCollection services)
        {
            _services = services;
        }

        internal void AddServices()
        {
            _services.AddTransient<ITenantRepository, TenantRepository>();
            _services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
