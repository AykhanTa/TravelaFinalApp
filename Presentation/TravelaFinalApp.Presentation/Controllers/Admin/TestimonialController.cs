using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelaFinalApp.Application.Dtos.TestimonialDtos;
using TravelaFinalApp.Application.Interfaces;

namespace TravelaFinalApp.Presentation.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
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
            await testimonialService.DeleteAsync(id);
            return Ok(new {Response="Data successfully deleted"});
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute]int id, [FromForm]TestimonialUpdateDto dto)
        {
            await testimonialService.UpdateAsync(id, dto);
            return Ok(new {Response="Data successfully updated"});

        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await testimonialService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await testimonialService.GetByIdAsync(id));
        }
    }
}
