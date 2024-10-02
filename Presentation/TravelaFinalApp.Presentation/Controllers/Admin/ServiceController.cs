using Microsoft.AspNetCore.Mvc;
using TravelaFinalApp.Application.Dtos.ServiceDtos;
using TravelaFinalApp.Application.Interfaces;

namespace TravelaFinalApp.Presentation.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    public class ServiceController(IServiceService serviceService) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> Create([FromForm]ServiceCreateDto serviceCreateDto)
        {
            await serviceService.CreateAsync(serviceCreateDto);
            return CreatedAtAction(nameof(Create), new { Response = "Data Successfully Created" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await serviceService.DeleteAsync(id);
            return Ok(new { Response = "Data successfully deleted.." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute]int id, [FromForm] ServiceUpdateDto serviceUpdateDto)
        {
            await serviceService.UpdateAsync(id, serviceUpdateDto);
            return Ok(new { Response = "Data successfully updated.." });

        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await serviceService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await serviceService.GetByIdAsync(id));
        }
    }
}
