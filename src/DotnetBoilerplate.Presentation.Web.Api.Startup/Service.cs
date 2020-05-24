using DotnetBoilerplate.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetBoilerplate.Presentation.Web.Api.Startup
{
    internal class Service
    {
        private readonly IServiceCollection _services;

        internal Service(IServiceCollection services)
        {
            _services = services;
        }

        internal void Configure()
        {
            _services.AddTransient<UserService>();
        }
    }
}
