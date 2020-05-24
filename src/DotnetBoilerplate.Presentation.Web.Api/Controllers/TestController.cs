using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly ILogger<TestController> _logger;
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
            //IList<User> users = _userRepository.AsQueryable().Where(t => t.Code == "test").ToList();

            return "test";
        }

        [HttpGet]
        [Route("add")]
        public async Task<int> Add(CancellationToken cancellationToken = default)
        {
            var user = await _userService.AddUserAsync("system@foobar.com", "System", 1, cancellationToken);

            return user.Id;
        }
    }
}
