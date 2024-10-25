using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelaFinalApp.Application.Interfaces;

namespace TravelaFinalApp.Presentation.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class SubscribeController(ISubscribeService subscribeService) : ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await subscribeService.GetAllAsync());
        }
    }
}
