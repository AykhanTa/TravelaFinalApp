using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelaFinalApp.Application.Dtos.AboutDtos;
using TravelaFinalApp.Application.Interfaces;
using TravelaFinalApp.Persistence.Implementations;

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
            await aboutService.DeleteAsync(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,AboutUpdateDto aboutUpdateDto)
        {
            await aboutService.UpdateAsync(id, aboutUpdateDto);
            return Ok();
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<List<AboutReturnDto>>(await aboutService.GetAllAsync()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<AboutReturnDto>(await aboutService.GetByIdAsync(id)));
        }

    }
}
