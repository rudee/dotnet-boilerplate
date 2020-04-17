using Microsoft.Extensions.Hosting;

namespace DotnetBoilerplate.Presentation.Web.Api
{
    public static class HostEnvironmentEnvExtensions
    {
        public static bool IsLocal(this IHostEnvironment hostEnvironment)
        {
            return hostEnvironment.IsEnvironment("Local");
        }
    }
}
