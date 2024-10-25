using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelaFinalApp.Application.Interfaces;
using TravelaFinalApp.Persistence.Implementations;

namespace TravelaFinalApp.Presentation.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class GetAppointmentController(IGetAppointmentService getAppointmentService) : ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> GetAll(int page, string? search)
        {
            return Ok(await getAppointmentService.GetAllAsync(page, search));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (id <= 0)
                return BadRequest("Id can't be zero or negative..");
            var existAppointment = await getAppointmentService.GetByIdAsync(id);
            return Ok(existAppointment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (id <= 0)
                return BadRequest("Id can't be zero or negative..");
            await getAppointmentService.DeleteAsync(id);
            return Ok(new { Response = "Data deleted successfully.." });
        }

    }
}
