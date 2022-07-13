using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PSL.Business.Interfaces;
using PSL.Entities.Dtos.User;

namespace PSL.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/users")]
    [ApiController]
    public class UserController : BaseController
    {

        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        
        public UserController( 
            IMapper mapper, 
            IUserService userService,
            IAuthService authService) : base(authService)
        {
            _mapper = mapper;
            _userService = userService;
            _authService = authService;
        }

        [HttpPost("users/create")]
        public async Task<IActionResult> CreateUser(UserCreateDto userDto)
        {
            var result = await _userService.Add(userDto, 1);

            return Ok(result.Data);
        }
    }
}
