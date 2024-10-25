using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelaFinalApp.Application.Interfaces;

namespace TravelaFinalApp.Presentation.Controllers.UI
{
    [Route("api/ui/[controller]/[action]")]
    [ApiController]
    public class TestimonialController(ITestimonialService testimonialService) : ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> GetAll(int page, string? search)
        {
            return Ok(await testimonialService.GetAllAsync(page, search));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            return Ok(await testimonialService.GetByIdAsync(id));
        }
    }
}
