using Microsoft.Extensions.DependencyInjection;

namespace Dnb.Presentation.WebApi.Configuration
{
    public static class ServiceCollectionServiceExtensions
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            Repositories.Configure(services);
            Services.Configure(services);

            return services;
        }
    }
}
