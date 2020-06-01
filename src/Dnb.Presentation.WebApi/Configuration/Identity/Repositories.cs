using Dnb.Domain.Repositories;
using Dnb.Identity.Domain.Entities;
using Dnb.Identity.Infrastructure.Repositories.EFCore;
using Dnb.Infrastructure.RepositoriesBase.EFCore;
using Microsoft.Extensions.DependencyInjection;

namespace Dnb.Presentation.WebApi.Configuration.Identity
{
    public static class Repositories
    {
        public static IServiceCollection Configure(IServiceCollection services)
        {
            services.AddTransient<IReadOnlyRepository<User, int, int>, ReadOnlyRepository<DbContext, User, int, int>>();

            //services.AddTransient<IReadOnlyRepository<Tenant, int>, ReadOnlyRepository<Tenant, int>>();


            return services;
        }
    }
}
