using System.Threading;
using System.Threading.Tasks;
using DotnetBoilerplate.Domain.Entities.Identity;
using DotnetBoilerplate.Domain.Repositories.Identity;
using Microsoft.Extensions.Logging;

namespace DotnetBoilerplate.Domain.Services
{
    public class UserService
    {
        private readonly ILogger<UserService> _logger;

        private readonly IUserRepository _userRepository;


        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> AddUserAsync(string email,
                                             string name,
                                             int createdByUserId,
                                             CancellationToken cancellationToken = default)
        {
            var user = new User
            {
                CreatedBy  = createdByUserId,
                ModifiedBy = createdByUserId,
                Email      = email,
                Name       = name
            };

            User newUser = await _userRepository.AddAsync(user, cancellationToken);

            return newUser;
        }
    }
}
