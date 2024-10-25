using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelaFinalApp.Application.Dtos.SliderDtos;
using TravelaFinalApp.Application.Interfaces;
using TravelaFinalApp.Persistence.Implementations;

namespace TravelaFinalApp.Presentation.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class SliderController(ISliderService sliderService, IMapper _mapper) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> Create(SliderCreateDto sliderCreateDto)
        {
            await sliderService.CreateAsync(sliderCreateDto);
            return CreatedAtAction(nameof(Create), new { Response = "Data created successfully.." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, SliderUpdateDto sliderUpdateDto)
        {
            if (id <= 0)
                return BadRequest("Id can't be zero or negative");
            await sliderService.UpdateAsync(id, sliderUpdateDto);
            return Ok(new { Response = "Data updated successfully.." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Id can't be zero or negative");
           await sliderService.DeleteAsync(id);
           return Ok(new { Response = "Data deleted successfully.." });
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<List<SliderReturnDto>>(await sliderService.GetAllAsync()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Id can't be zero or negative");
            return Ok(_mapper.Map<SliderReturnDto>(await sliderService.GetByIdAsync(id)));
        }

        
    }
}
