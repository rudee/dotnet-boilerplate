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

        public async Task<User> AddUserAsync(string            email,
                                             string            name,
                                             int               createdByUserId,
                                             CancellationToken cancellationToken = default)
        {
            var user = new User
            {
                CreatedBy  = createdByUserId,
                ModifiedBy = createdByUserId,
                Email      = email,
                Name       = name
            };

            User addedUser = await _userRepository.AddAsync(user, cancellationToken).ConfigureAwait(false);

            return addedUser;
        }

        public async Task<User> UpdateUserAsync(int               id,
                                                string            email,
                                                string            name,
                                                int               modifiedByUserId,
                                                CancellationToken cancellationToken = default)
        {

            User user = await _userRepository.FindAsync(u => u.Id == id).ConfigureAwait(false);
            user.Email      = email;
            user.Name       = name;
            user.ModifiedBy = modifiedByUserId;

            User updatedUser = await _userRepository.UpdateAsync(user, cancellationToken).ConfigureAwait(false);

            return updatedUser;
        }
    }
}
