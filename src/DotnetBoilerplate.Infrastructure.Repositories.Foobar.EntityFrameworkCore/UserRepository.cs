using DotnetBoilerplate.Domain.Entities.Foobar;
using DotnetBoilerplate.Domain.Repositories.Foobar;
using DotnetBoilerplate.Infrastructure.Repositories.EntityFrameworkCore;

namespace DotnetBoilerplate.Infrastructure.Repositories.Foobar.EntityFrameworkCore
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(FoobarDbContext context)
            : base(context)
        {
        }
    }
}
