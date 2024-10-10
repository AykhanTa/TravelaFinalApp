using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelaFinalApp.Application.Dtos.GuideSocialDtos;
using TravelaFinalApp.Application.Interfaces;

namespace TravelaFinalApp.Presentation.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    public class GuideSocialController(IGuideSocialService guideSocialService) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> Create([FromForm]GuideSocialCreateDto dto)
        {
            await guideSocialService.CreateAsync(dto);
            return CreatedAtAction(nameof(Create), new { Response = "Data created successfully.." });
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute]int id,[FromBody]GuideSocialUpdateDto dto)
        {
            await guideSocialService.UpdateAsync(id,dto);
            return Ok(new {Response="Data updated successfully"});
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            await guideSocialService.DeleteAsync(id);
            return Ok(new {Response="Data deleted successfully"});
        }


        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await guideSocialService.GetAllAsync());
        }
    }
}
