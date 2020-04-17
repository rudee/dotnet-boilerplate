using Microsoft.Extensions.DependencyInjection;

namespace DotnetBoilerplate.Presentation.Web.Api.DependencyInjection
{
    public static class ServiceCollectionServiceExtensions
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            var repositoryDependencyInjection = new RepositoryDependencyInjection(services);
            repositoryDependencyInjection.AddServices();

            return services;
        }
    }
}
