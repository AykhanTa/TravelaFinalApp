using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelaFinalApp.Application.Dtos.ContactDtos;
using TravelaFinalApp.Application.Interfaces;

namespace TravelaFinalApp.Presentation.Controllers.UI
{
    [Route("api/ui/[controller]/[action]")]
    [ApiController]
    public class ContactController(IContactService contactService) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> Create(ContactCreateDto contactCreateDto)
        {
            await contactService.CreateAsync(contactCreateDto);
            return CreatedAtAction(nameof(Create), new { Response = "Data created successfully.." });
        }
    }
}
