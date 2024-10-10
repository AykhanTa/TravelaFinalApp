using Microsoft.AspNetCore.Mvc;
using TravelaFinalApp.Application.Dtos.GuideDtos;
using TravelaFinalApp.Application.Interfaces;

namespace TravelaFinalApp.Presentation.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    public class GuideController(IGuideService guideService) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> Create(GuideCreateDto dto)
        {
            await guideService.CreateAsync(dto);
            return CreatedAtAction(nameof(Create), new { Response = "Data created successfully.." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await guideService.DeleteAsync(id);
            return Ok(new { Response = "Data deleted successfully" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromForm] GuideUpdateDto dto)
        {
            await guideService.UpdateAsync(id, dto);
            return Ok(new { Response = "Data updated successfully.." });
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await guideService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await guideService.GetByIdAsync(id));
        }
    }
}
