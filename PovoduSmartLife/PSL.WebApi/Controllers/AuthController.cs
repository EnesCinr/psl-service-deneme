using Microsoft.AspNetCore.Mvc;

namespace PSL.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/authentication")]
    [ApiController]
    public class AuthController : BaseController
    {
        public IActionResult Index()
        {
            return null;
        }
    }
}
