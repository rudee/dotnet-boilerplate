using System;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Dnb.Identity.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
//using Dnb.Identity.Domain.Repositories;
using Dnb.Domain.Repositories;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Dnb.Presentation.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IReadOnlyRepository<User, int, int> _userRepository;

        public UserController(ILogger<UserController>   logger,
                              IReadOnlyRepository<User, int, int> userRepository)
        {
            _logger         = logger;
            //_userService    = userService;
            _userRepository = userRepository;
        }

        [HttpGet("{id?}")]
        public async Task<IActionResult> Get(int?              id,
                                             CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                //IQueryable<User> q = _userRepository.AsQueryable(
                //    new NavigationPropertyTree<User, object>
                //    {
                //        Path = u => u.TenantUsers
                //    }
                //);
                //return Ok(q);

                IQueryable<User> q = _userRepository.AsQueryable()
                    .Select(u => new User
                    {
                        Id    = u.Id,
                        Guid  = u.Guid,
                        Email = u.Email,
                        Name  = u.Name,
                        //TenantUsers = u.TenantUsers
                        TenantUsers = u.TenantUsers.Select(tu => new TenantUser
                        {
                            Id = tu.Id,
                            Tenant = tu.Tenant,
                            User = tu.User
                        }).ToImmutableArray()
                    });
                return Ok(q);

                //return Ok(await _userRepository.GetAllAsync(null, cancellationToken));
            }

            User user = await _userRepository.GetAsync(id.Value,
                                                       u => new User
                                                       {
                                                           Id = u.Id,
                                                           Email = u.Email,
                                                           Name = u.Name
                                                       },
                                                       cancellationToken);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        /*
        [HttpGet]
        [Route("add")]
        public async Task<string> Add(CancellationToken cancellationToken = default)
        {
            var user = await _userService
                .AddUserAsync("system@foobar.com",
                              "System",
                              1,
                              cancellationToken)
                .ConfigureAwait(false);

            return JsonSerializer.Serialize(user, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }

        [HttpGet]
        [Route("update/{id}")]
        public async Task<string> Update(int id, CancellationToken cancellationToken = default)
        {
            var user = await _userService
                .UpdateUserAsync(id,
                                 "system@foobar.com",
                                 "System",
                                 1,
                                 cancellationToken)
                .ConfigureAwait(false);

            return JsonSerializer.Serialize(user, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }
        */
    }
}
