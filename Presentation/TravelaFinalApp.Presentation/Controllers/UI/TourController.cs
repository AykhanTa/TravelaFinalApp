using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelaFinalApp.Application.Interfaces;
using TravelaFinalApp.Persistence.Implementations;

namespace TravelaFinalApp.Presentation.Controllers.UI
{
    [Route("api/ui/[controller]/[action]")]
    [ApiController]
    public class TourController(ITourService tourService) : ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> GetAll(int page, string? search)
        {
            return Ok(await tourService.GetAllAsync(page, search));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await tourService.GetByIdAsync(id));
        }
    }
}
