using DotnetBoilerplate.Domain.Repositories.Identity;
using DotnetBoilerplate.Infrastructure.Repositories.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetBoilerplate.Presentation.Web.Api.Startup
{
    internal class Repository
    {
        private readonly IServiceCollection _services;

        internal Repository(IServiceCollection services)
        {
            _services = services;
        }

        internal void Configure()
        {
            //_services.AddTransient<IDocumentRepository, DocumentRepository>();
            //_services.AddTransient<IDocumentStatusRepository, DocumentStatusRepository>();
            //_services.AddTransient<IScheduleRepository, ScheduleRepository>();

            _services.AddTransient<ITenantRepository, TenantRepository>();
        }
    }
}
