using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PSL.Business.Interfaces;
using PSL.Core.Entities.Concrete;
using PSL.Core.Utilities.Regex;
using PSL.Core.Utilities.Results;
using PSL.Entities.Dtos.Auth;
using System.Security.Claims;

namespace PSL.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/authentication")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public AuthController(IMapper mapper, IAuthService authService, IUserService userService) : base(authService)
        {
            _mapper = mapper;
            _authService = authService;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await UserLogin(loginDto);

            if (!user.Success)
            {
                return BadRequest(user.Message);
            }

            return await GetUserAccessInformations(user.Data);
        }

        private async Task<IDataResult<JwtAuthUser>> UserLogin(LoginDto loginDto)
        {
            var userToLogin = await _authService.LoginWithUsername(loginDto.IdentifierInfo, loginDto.Password, GenerateIPAddress());
            //mail ile login için kullanılabilir.
            //RegexHelper.IsEmail(loginDto.IdentifierInfo)
                //? await _authService.LoginWithEmail(loginDto.IdentifierInfo, loginDto.Password, GenerateIPAddress())
                //: await _authService.LoginWithUsername(loginDto.IdentifierInfo, loginDto.Password, GenerateIPAddress());

            if (!userToLogin.Success)
                return new ErrorDataResult<JwtAuthUser>(userToLogin.Message);

            return userToLogin;
        }
        private string GenerateIPAddress()
        {
            return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }

        private async Task<IActionResult> GetUserAccessInformations(JwtAuthUser jwtAuthUser)
        {            

            var result = _authService.CreateAccessToken(jwtAuthUser);
            if (!result.Success)
                return BadRequest(result.Message);

            // TODO: model oluşturalım daha sonra.
            return Ok(new
            {
                user = jwtAuthUser,
                accessToken = result.Data.Token,
                accessTokenExpiration = result.Data.Expiration
            });
        }
    }
}
