using Microsoft.Extensions.Hosting;

namespace DotnetBoilerplate.Presentation.Web.Api
{
    public static class HostEnvironmentExtensions
    {
        public static bool IsLocal(this IHostEnvironment hostEnvironment)
        {
            return hostEnvironment.IsEnvironment("Local");
        }
    }
}
