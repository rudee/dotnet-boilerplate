using System;
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
            services.AddTransient<IRepository<Tenant, int, Guid>, Repository<DbContext, Tenant, int, Guid>>();
            services.AddTransient<IRepository<User, Guid, Guid>, Repository<DbContext, User, Guid, Guid>>();


            return services;
        }
    }
}
