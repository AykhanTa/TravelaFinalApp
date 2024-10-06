using Microsoft.AspNetCore.Mvc;
using TravelaFinalApp.Application.Dtos.DestinationDtos;
using TravelaFinalApp.Application.Interfaces;
using TravelaFinalApp.Persistence.Implementations;

namespace TravelaFinalApp.Presentation.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    public class DestinationController(IDestinationService destinationService) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> Create(DestinationCreateDto dto)
        {
            await destinationService.CreateAsync(dto);
            return CreatedAtAction(nameof(Create), new { Response = "Data successfully created.." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            await destinationService.DeleteAsync(id);
            return Ok(new { Response = "Data successfully deleted" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute]int id, DestinationUpdateDto dto)
        {
            await destinationService.UpdateAsync(id,dto);
            return Ok(new { Response = "Data successfully updated" });
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await destinationService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await destinationService.GetByIdAsync(id));
        }
    }
}
