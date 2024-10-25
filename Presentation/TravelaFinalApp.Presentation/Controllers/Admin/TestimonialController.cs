using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelaFinalApp.Application.Dtos.TestimonialDtos;
using TravelaFinalApp.Application.Interfaces;

namespace TravelaFinalApp.Presentation.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class TestimonialController(ITestimonialService testimonialService) : ControllerBase
    {

        [HttpPost("")]
        public async Task<IActionResult> Create([FromForm]TestimonialCreateDto dto)
        {
            await testimonialService.CreateAsync(dto);
            return CreatedAtAction(nameof(Create), new {Response="Data successfully created"});    
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            if (id <= 0)
                return BadRequest("Id can't be zero or negative");
            await testimonialService.DeleteAsync(id);
            return Ok(new {Response="Data successfully deleted"});
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute]int id, [FromForm]TestimonialUpdateDto dto)
        {
            if (id <= 0)
                return BadRequest("Id can't be zero or negative");
            await testimonialService.UpdateAsync(id, dto);
            return Ok(new {Response="Data successfully updated"});

        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll(int page,string? search)
        {
            return Ok(await testimonialService.GetAllAsync(page,search));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (id <= 0)
                return BadRequest("Id can't be zero or negative");
            return Ok(await testimonialService.GetByIdAsync(id));
        }
    }
}
