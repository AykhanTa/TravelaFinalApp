using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelaFinalApp.Application.Dtos.UserDtos;
using TravelaFinalApp.Application.Helpers.Account;
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

        [HttpGet("")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await authService.GetAllUsersAsync());
        }

        [HttpGet]
        public async Task<IActionResult> VerifyEmail(string verifyEmail,string token)
        {
            if (VerifyEmail == null || token == null) return BadRequest("Something went wrong");
             await authService.VerifyEmail(verifyEmail, token);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(string email)
        {
            if (email == null)
                return BadRequest("Email not found. Make sure you typed correctly!");
            var scheme = HttpContext.Request.Scheme;
            var host = HttpContext.Request.Host.Value;
            ResponseObj responseObj = await authService.ForgetPassword(email, scheme, host);
            if (responseObj.StatusCode == (int)StatusCodes.Status400BadRequest) return BadRequest(responseObj.ResponseMessage);
            else if (responseObj.StatusCode == (int)StatusCodes.Status404NotFound) return NotFound(responseObj.ResponseMessage);

            return Ok(responseObj.ResponseMessage);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(UserResetPasswordDto resetPasswordDto)
        {
            ResponseObj responseObj=await authService.ResetPassword(resetPasswordDto);
            if (responseObj.StatusCode == (int)StatusCodes.Status400BadRequest) return BadRequest(responseObj.ResponseMessage);
            else if (responseObj.StatusCode == (int)StatusCodes.Status404NotFound) return NotFound(responseObj.ResponseMessage);

            return Ok(responseObj.ResponseMessage);
        }

    }
}
