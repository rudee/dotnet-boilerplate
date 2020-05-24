using Microsoft.Extensions.DependencyInjection;

namespace DotnetBoilerplate.Presentation.Web.Api.Configuration
{
    public static class ServiceCollectionServiceExtensions
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddRepositoryDependencyInjection();
            services.AddServiceDependencyInjection();

            return services;
        }
    }
}
