using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelaFinalApp.Application.Dtos.BlogDtos;
using TravelaFinalApp.Application.Interfaces;
using TravelaFinalApp.Persistence.Implementations;

namespace TravelaFinalApp.Presentation.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
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
            if (id <= 0)
                return BadRequest("Id can't be zero or negative");
            await blogService.UpdateAsync(id,dto);
            return Ok(new { Response = "Data successfully updated" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            if (id <= 0)
                return BadRequest("Id can't be zero or negative");
            await blogService.DeleteAsync(id);
            return Ok(new { Response = "Data successfully deleted" });
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll(int page, string? search)
        {
            return Ok(await blogService.GetAllAsync(page,search));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (id <= 0)
                return BadRequest("Id can't be zero or negative");
            return Ok(await blogService.GetByIdAsync(id));
        }
    }
}
