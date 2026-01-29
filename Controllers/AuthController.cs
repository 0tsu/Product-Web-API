using Estudo.DTOs;
using Estudo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Estudo.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginDto dto)
        {
            var token = _userService.Login(dto);
            return Ok(token);
        }

        [HttpPost("register")]
        public IActionResult Register(UserCreateDto dto)
        {
            _userService.Register(dto);
            return Ok();
        }
    }
}
