using DotnetBoilerplate.Domain.Entities.Foobar;
using DotnetBoilerplate.Domain.Repositories.Foobar;
using DotnetBoilerplate.Infrastructure.RepositoriesBase.EntityFrameworkCore;

namespace DotnetBoilerplate.Infrastructure.Repositories.Foobar.EntityFrameworkCore
{
    public class DocumentStatusRepository : RepositoryBase<DocumentStatus>, IDocumentStatusRepository
    {
        public DocumentStatusRepository(FoobarDbContext context)
            : base(context)
        {
        }
    }
}
