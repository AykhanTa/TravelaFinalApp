using Microsoft.AspNetCore.Mvc;
using TravelaFinalApp.Application.Dtos.PackageDtos;
using TravelaFinalApp.Application.Interfaces;

namespace TravelaFinalApp.Presentation.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    public class PackageController(IPackageService packageService) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> Create(PackageCreateDto packageCreateDto)
        {
            await packageService.CreateAsync(packageCreateDto);
            return CreatedAtAction(nameof(Create), new { Response = "Data created successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await packageService.DeleteAsync(id);
            return Ok(new { Response = "Data deleted successfully" });
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll(int page,string? search)
        {
            return Ok(await packageService.GetAllAsync(page,search));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await packageService.GetByIdAsync(id));
        }
    }
}
