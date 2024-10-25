using Microsoft.AspNetCore.Mvc;
using TravelaFinalApp.Application.Interfaces;

namespace TravelaFinalApp.Presentation.Controllers.UI
{
    [Route("api/ui/[controller]/[action]")]
    [ApiController]
    public class DestinationController(IDestinationService destinationService) : ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await destinationService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            if(id>0)
                return Ok(await destinationService.GetByIdAsync(id));
            return BadRequest("Id can't be zero or negative");
        }
    }
}
