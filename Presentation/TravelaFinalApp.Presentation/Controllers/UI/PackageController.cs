using Microsoft.AspNetCore.Mvc;
using TravelaFinalApp.Application.Interfaces;
using TravelaFinalApp.Persistence.Implementations;

namespace TravelaFinalApp.Presentation.Controllers.UI
{
    [Route("api/ui/[controller]/[action]")]
    [ApiController]
    public class PackageController(IPackageService packageService ) : ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> GetAll(int page,string? search)
        {
            return Ok(await packageService.GetAllAsync(page,search));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if(id>0)
                return Ok(await packageService.GetByIdAsync(id));
            return BadRequest("Id can't be zero or negative");
        }
    }
}
