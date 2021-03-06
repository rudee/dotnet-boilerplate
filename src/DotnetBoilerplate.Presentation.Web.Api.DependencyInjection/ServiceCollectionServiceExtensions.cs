using Microsoft.Extensions.DependencyInjection;

namespace DotnetBoilerplate.Presentation.Web.Api.DependencyInjection
{
    public static class ServiceCollectionServiceExtensions
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            var repositoryDependencyInjection = new RepositoryDependencyInjection(services);
            repositoryDependencyInjection.AddServices();

            services.AddTransient<UserService>()
            

            return services;
        }
    }
}
