//using Dnb.Domain.Repositories;
//using Dnb.Identity.Domain.Entities;
//using Dnb.Identity.Domain.Repositories;
using Dnb.Identity.Infrastructure.Repositories.EFCore;
using Dnb.Infrastructure.RepositoriesBase.EFCore;
using Microsoft.Extensions.DependencyInjection;

namespace Dnb.Presentation.WebApi.Configuration
{
    public static class Repositories
    {
        public static IServiceCollection AddRepositoryDependencyInjection(this IServiceCollection services)
        {

            //services.AddTransient<Dnb.Identity.Domain.Repositories.IReadOnlyRepository<User, int>, Dnb.Identity.Infrastructure.Repositories.EFCore.ReadOnlyRepository<User, int>>();
            //ReadOnlyRepository<TDbContext, TEntity, TPrimaryKey, TUserId>

            //services.AddTransient<IReadOnlyRepository<User, int>, ReadOnlyRepository<User, int>>();

            //services.AddTransient<ITenantRepository, TenantRepository>();
            //services.AddTransient<IUserRepository, UserRepository>();

            //services.AddTransient<IDocumentRepository, DocumentRepository>();
            //services.AddTransient<IDocumentStatusRepository, DocumentStatusRepository>();
            //services.AddTransient<IScheduleRepository, ScheduleRepository>();

            return services;
        }

        public static IServiceCollection Configure(IServiceCollection services)
        {
            Identity.Repositories.Configure(services);

            return services;
        }
    }
}
