using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelaFinalApp.Application.Dtos.GetAppointmentDtos;
using TravelaFinalApp.Application.Interfaces;

namespace TravelaFinalApp.Presentation.Controllers.UI
{
    [Route("api/ui/[controller]/[action]")]
    [ApiController]
    public class GetAppointmentController(IGetAppointmentService getAppointmentService) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> Create(GetAppointmentCreateDto createDto)
        {
            await getAppointmentService.CreateAsync(createDto);
            return CreatedAtAction(nameof(Create), new {Response="Data created successfully"});
        }
    }
}
