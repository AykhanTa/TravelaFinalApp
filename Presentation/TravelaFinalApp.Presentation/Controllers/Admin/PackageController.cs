using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelaFinalApp.Application.Dtos.PackageDtos;
using TravelaFinalApp.Application.Dtos.TourDtos;
using TravelaFinalApp.Application.Interfaces;
using TravelaFinalApp.Persistence.Implementations;

namespace TravelaFinalApp.Presentation.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class PackageController(IPackageService packageService) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> Create(PackageCreateDto packageCreateDto)
        {
            await packageService.CreateAsync(packageCreateDto);
            return CreatedAtAction(nameof(Create), new { Response = "Data created successfully" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, PackageUpdateDto packageUpdateDto)
        {
            if (id <= 0)
                return BadRequest("Id can't be zero or negative");
            await packageService.UpdateAsync(id, packageUpdateDto);
            return Ok(new { Response = "Data updated successfuly.." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Id can't be zero or negative");
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
            if (id <= 0)
                return BadRequest("Id can't be zero or negative");
            return Ok(await packageService.GetByIdAsync(id));
        }
    }
}
