using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelaFinalApp.Application.Dtos.UserDtos;
using TravelaFinalApp.Application.Interfaces;

namespace TravelaFinalApp.Presentation.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> AddRole(RoleAssignmentDto roleAssignmentDto)
        {
            if (roleAssignmentDto == null || string.IsNullOrWhiteSpace(roleAssignmentDto.UserName) || string.IsNullOrWhiteSpace(roleAssignmentDto.RoleName))
                return BadRequest("Invalid request..");
            var response = await authService.AddRoleAsync(roleAssignmentDto.UserName, roleAssignmentDto.RoleName);

            if(response.StatusCode==StatusCodes.Status200OK)
                return Ok(response.ResponseMessage);

            return BadRequest(response.ResponseMessage);
        }

        [HttpPost("")]
        public async Task<IActionResult> RemoveRole(RoleAssignmentDto roleAssignmentDto)
        {
            if (roleAssignmentDto == null || string.IsNullOrWhiteSpace(roleAssignmentDto.UserName) || string.IsNullOrWhiteSpace(roleAssignmentDto.RoleName))
                return BadRequest("Invalid request..");
            var response = await authService.RemoveRoleAsync(roleAssignmentDto.UserName, roleAssignmentDto.RoleName);

            if (response.StatusCode == StatusCodes.Status200OK)
                return Ok(response.ResponseMessage);

            return BadRequest(response.ResponseMessage);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await authService.GetAllUsersAsync());
        }
    }
}
