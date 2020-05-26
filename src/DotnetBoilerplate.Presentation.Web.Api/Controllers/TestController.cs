using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using DotnetBoilerplate.Domain.Entities.Identity;
using DotnetBoilerplate.Domain.Repositories.Identity;
using DotnetBoilerplate.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotnetBoilerplate.Presentation.Web.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly UserService _userService;
        private readonly IUserRepository _userRepository;

        public TestController(ILogger<TestController> logger,
                              UserService userService,
                              IUserRepository userRepository)
        {
            _logger = logger;
            _userService = userService;
            _userRepository = userRepository;
        }

        [HttpGet]
        public string Get()
        {
            User user = _userRepository.AsQueryable().FirstOrDefault();

            return JsonSerializer.Serialize(user, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }

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
    }
}
