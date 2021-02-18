using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TinyBank.Interfaces;
using TinyBank.Types.Requests;
using TinyBank.Types.Responses;

namespace TinyBank.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> logger;
        private readonly IUserService userService;

        public UserController(ILogger<UserController> _logger, IUserService _userService)
        {
            logger = _logger;
            userService = _userService;
        }

        [HttpPost("registrationUser")]
        public async Task<ActionResult<RegisterUserResponse>> RegistrationUser(RegisterUserRequest request)
        {
            var result = await userService.RegistrationUserAsync(request);
            return result;
        }
    }
}
