using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelaFinalApp.Application.Dtos.AboutDtos;
using TravelaFinalApp.Application.Interfaces;

namespace TravelaFinalApp.Presentation.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class AboutController(IAboutService aboutService,IMapper _mapper) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> Create([FromForm]AboutCreateDto aboutCreateDto)
        {
            await aboutService.CreateAsync(aboutCreateDto);
            return CreatedAtAction(nameof(Create), new { Response = "Data Successfully Created" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Id can't be zero or negative");
            await aboutService.DeleteAsync(id);
            return Ok(new { Response = "Data deleted successfully" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,AboutUpdateDto aboutUpdateDto)
        {
            if (id <= 0)
                return BadRequest("Id can't be zero or negative");
            await aboutService.UpdateAsync(id, aboutUpdateDto);
            return Ok(new { Response = "Data updated successfully" });
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<List<AboutReturnDto>>(await aboutService.GetAllAsync()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Id can't be zero or negative");
            return Ok(_mapper.Map<AboutReturnDto>(await aboutService.GetByIdAsync(id)));
        }

    }
}
