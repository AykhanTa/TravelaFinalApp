using Microsoft.AspNetCore.Mvc;
using TravelaFinalApp.Application.Interfaces;
using TravelaFinalApp.Persistence.Implementations;

namespace TravelaFinalApp.Presentation.Controllers.UI
{
    [Route("api/ui/[controller]/[action]")]
    [ApiController]
    public class GuideSocialController(IGuideSocialService guideSocialService) : ControllerBase
    {

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await guideSocialService.GetAllAsync());
        }
    }
}
