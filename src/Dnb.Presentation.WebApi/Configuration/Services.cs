using Microsoft.Extensions.DependencyInjection;

namespace Dnb.Presentation.WebApi.Configuration
{
    public static class Services
    {
        public static IServiceCollection Configure(IServiceCollection services)
        {
            //services.AddTransient<UserService>();

            return services;
        }
    }
}
