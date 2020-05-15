using DotnetBoilerplate.Domain.Entities.Identity;
using DotnetBoilerplate.Domain.Repositories.Identity;
using DotnetBoilerplate.Infrastructure.RepositoriesBase.EntityFrameworkCore;

namespace DotnetBoilerplate.Infrastructure.Repositories.Identity.EntityFrameworkCore
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IdentityDbContext context)
            : base(context)
        {
        }
    }
}
