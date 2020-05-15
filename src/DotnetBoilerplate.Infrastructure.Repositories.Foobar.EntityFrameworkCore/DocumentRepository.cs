using DotnetBoilerplate.Domain.Entities.Foobar;
using DotnetBoilerplate.Domain.Repositories.Foobar;
using DotnetBoilerplate.Infrastructure.RepositoriesBase.EntityFrameworkCore;

namespace DotnetBoilerplate.Infrastructure.Repositories.Foobar.EntityFrameworkCore
{
    public class DocumentRepository : RepositoryBase<Document>, IDocumentRepository
    {
        public DocumentRepository(FoobarDbContext context)
            : base(context)
        {
        }
    }
}
