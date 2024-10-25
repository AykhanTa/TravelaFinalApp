using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelaFinalApp.Application.Interfaces;

namespace TravelaFinalApp.Presentation.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ContactController(IContactService contactService) : ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> GetAll(int page,string? search)
        {
            return Ok(await contactService.GetAllAsync(page, search));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            if (id <= 0)
                return BadRequest("Id can't be zero or negative");
            var existContact=await contactService.GetByIdAsync(id);
            return Ok(existContact);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            if (id <= 0)
                return BadRequest("Id can't be zero or negative");
            await contactService.DeleteAsync(id);
            return Ok(new {Response="Data deleted successfully.."});
        }
    }
}
