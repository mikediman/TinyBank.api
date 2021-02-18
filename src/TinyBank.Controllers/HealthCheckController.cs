
using Microsoft.AspNetCore.Mvc;
using TinyBank.Types.Requests;

namespace TinyBank.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class HealthCheckController : ControllerBase
    {
        public HealthCheckController() { }

        [HttpGet]
        public IActionResult HealthCheck(GenericRequest request)
        {
            return Content("The ASP.NET Core Api is running!");
        }
    }
}
