using DotnetBoilerplate.Domain.Repositories.Foobar;
using DotnetBoilerplate.Domain.Repositories.Identity;
using DotnetBoilerplate.Infrastructure.Repositories.Foobar.EntityFrameworkCore;
using DotnetBoilerplate.Infrastructure.Repositories.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetBoilerplate.Presentation.Web.Api.DependencyInjection
{
    internal class RepositoryDependencyInjection
    {
        private readonly IServiceCollection _services;

        internal RepositoryDependencyInjection(IServiceCollection services)
        {
            _services = services;
        }

        internal void AddServices()
        {
            //_services.AddTransient<IDocumentRepository, DocumentRepository>();
            //_services.AddTransient<IDocumentStatusRepository, DocumentStatusRepository>();
            //_services.AddTransient<IScheduleRepository, ScheduleRepository>();

            _services.AddTransient<ITenantRepository, TenantRepository>();
        }
    }
}
