using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelaFinalApp.Application.Dtos.TourDtos;
using TravelaFinalApp.Application.Interfaces;

namespace TravelaFinalApp.Presentation.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    public class TourController(ITourService tourService) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> Create([FromForm]TourCreateDto tourCreateDto)
        {
            await tourService.CreateAsync(tourCreateDto);
            return CreatedAtAction(nameof(Create), new { Response = "Data created successfully.." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            await tourService.DeleteAsync(id);
            return Ok(new { Response = "Data deleted successfully.." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute]int id,TourUpdateDto tourUpdateDto)
        {
            await tourService.UpdateAsync(id, tourUpdateDto);
            return Ok(new { Response = "Data updated successfuly.." });
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await tourService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            return Ok(await tourService.GetByIdAsync(id));
        }
    }
}
