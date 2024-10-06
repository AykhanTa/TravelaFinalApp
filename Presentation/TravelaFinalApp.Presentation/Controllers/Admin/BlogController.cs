using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelaFinalApp.Application.Dtos.BlogDtos;
using TravelaFinalApp.Application.Interfaces;
using TravelaFinalApp.Persistence.Implementations;

namespace TravelaFinalApp.Presentation.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    public class BlogController(IBlogService blogService) : ControllerBase
    {

        [HttpPost("")]
        public async Task<IActionResult> Create([FromForm]BlogCreateDto dto)
        {
            await blogService.CreateAsync(dto);
            return CreatedAtAction(nameof(Create), new { Response = "Data successfully created" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute]int id,BlogUpdateDto dto)
        {
            await blogService.UpdateAsync(id,dto);
            return Ok(new { Response = "Data successfully updated" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            await blogService.DeleteAsync(id);
            return Ok(new { Response = "Data successfully deleted" });
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await blogService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await blogService.GetByIdAsync(id));
        }
    }
}
