using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelaFinalApp.Application.Interfaces;

namespace TravelaFinalApp.Presentation.Controllers.UI
{
    [Route("api/ui/[controller]/[action]")]
    [ApiController]
    public class BlogController(IBlogService blogService) : ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> GetAll(int page,string? search)
        {
            return Ok(await blogService.GetAllAsync(page,search));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            if(id>0)
                return Ok(await blogService.GetByIdAsync(id));
            return BadRequest("Id can't be zero or negative");
        }
    }
}
