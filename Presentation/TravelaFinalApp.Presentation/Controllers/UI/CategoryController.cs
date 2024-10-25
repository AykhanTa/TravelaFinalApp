using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelaFinalApp.Application.Interfaces;

namespace TravelaFinalApp.Presentation.Controllers.UI
{
    [Route("api/ui/[controller]/[action]")]
    [ApiController]
    public class CategoryController(ICategoryService categoryService) : ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await categoryService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if(id>0)
                return Ok(await categoryService.GetByIdAsync(id));
            return BadRequest("Id can't be zero or negative");
        }
    }
}
