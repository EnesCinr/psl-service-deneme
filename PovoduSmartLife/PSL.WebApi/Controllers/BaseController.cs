using Microsoft.AspNetCore.Mvc;

namespace PSL.WebApi.Controllers
{
    public class BaseController : ControllerBase
    {
        //private readonly IAuthService _authService;
        public BaseController()
        {
        }

        public IActionResult Index()
        {
            return null;
        }
    }
}
