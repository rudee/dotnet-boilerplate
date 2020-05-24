using DotnetBoilerplate.Domain.Repositories.Identity;
using DotnetBoilerplate.Infrastructure.Repositories.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetBoilerplate.Presentation.Web.Api.Configuration
{
    public static class RepositoryDependencyInjection
    {
        public static IServiceCollection AddRepositoryDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<ITenantRepository, TenantRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            //services.AddTransient<IDocumentRepository, DocumentRepository>();
            //services.AddTransient<IDocumentStatusRepository, DocumentStatusRepository>();
            //services.AddTransient<IScheduleRepository, ScheduleRepository>();

            return services;
        }
    }
}
