using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PSL.Business.Constants;
using PSL.Business.Interfaces;
using PSL.Core.Entities.Concrete;
using System.Security.Claims;

namespace PSL.WebApi.Controllers
{
    public class BaseController : ControllerBase
    {
        //private readonly IAuthService _authService;
        private readonly IAuthService _authService;

        public BaseController(IAuthService authService)
        {
            _authService = authService;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<JwtAuthUser> GetLoggedUserInformation()
        {
            var authHeader = HttpContext.Request.Headers["Authorization"];
            if (string.IsNullOrWhiteSpace(authHeader))
                throw new Exception(Messages.AuthorizationDenied);

            var userDataClaim = await _authService.GetClaim(authHeader, ClaimTypes.UserData);

            if (!userDataClaim.Success)
                throw new Exception(Messages.AuthorizationDenied);

            var jwtAuthUser = JsonConvert.DeserializeObject<JwtAuthUser>(userDataClaim.Data);
            if (jwtAuthUser == null)
                throw new Exception(Messages.AuthorizationDenied);

            return jwtAuthUser;
        }
    }
}
