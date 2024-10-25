using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelaFinalApp.Application.Dtos.SettingDtos;
using TravelaFinalApp.Application.Interfaces;

namespace TravelaFinalApp.Presentation.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class SettingController(ISettingService settingService) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> Create(SettingCreateDto dto)
        {
            await settingService.CreateAsync(dto);
            return CreatedAtAction(nameof(Create), new {Response="Data created successfully.." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute]int id, SettingUpdateDto settingUpdateDto)
        {
            if (id <= 0)
                return BadRequest("Id can't be zero or negative");
            await settingService.UpdateAsync(id, settingUpdateDto);
            return Ok(new { Response = "Data updated successfully.." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            if (id <= 0)
                return BadRequest("Id can't be zero or negative");
            await settingService.DeleteAsync(id);
            return Ok(new { Response = "Data deleted successfully" });
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await settingService.GetAllAsync());
        }
    }
}
