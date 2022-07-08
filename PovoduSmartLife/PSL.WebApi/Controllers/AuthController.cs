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

        public AuthController(IMapper mapper, IAuthService authService) : base(authService)
        {
            _mapper = mapper;
            _authService = authService;
        }

        [HttpPost]
        // TODO: İçerik business'a taşınmalı.
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await UserLogin(loginDto);

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
            //düzenle
            return Ok();
        }
    }
}
