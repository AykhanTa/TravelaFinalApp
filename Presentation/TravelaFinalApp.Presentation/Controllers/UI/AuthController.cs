using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelaFinalApp.Application.Dtos.UserDtos;
using TravelaFinalApp.Application.Interfaces;

namespace TravelaFinalApp.Presentation.Controllers.UI
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            return Ok(await authService.SignUpAsync(registerDto));
        }

        [HttpPost("")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            return Ok(await authService.SignInAsync(loginDto));
        }

    }
}
