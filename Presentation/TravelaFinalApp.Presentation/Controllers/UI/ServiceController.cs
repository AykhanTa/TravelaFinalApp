using Microsoft.AspNetCore.Mvc;
using TravelaFinalApp.Application.Interfaces;

namespace TravelaFinalApp.Presentation.Controllers.UI
{
    [Route("api/ui/[controller]/[action]")]
    [ApiController]
    public class ServiceController(IServiceService serviceService) : ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await serviceService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if(id>0)
                return Ok(await serviceService.GetByIdAsync(id));
            return BadRequest("Id can't be zero or negative");
        }
    }
}
