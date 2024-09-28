using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelaFinalApp.Application.Dtos.SliderDtos;
using TravelaFinalApp.Application.Interfaces;

namespace TravelaFinalApp.Presentation.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    public class SliderController(ISliderService sliderService, IMapper _mapper) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> Create(SliderCreateDto sliderCreateDto)
        {
            return Ok(await sliderService.CreateAsync(sliderCreateDto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, SliderUpdateDto sliderUpdateDto)
        {
            if (id == null)
                return BadRequest("Id can not be null");
            return Ok(await sliderService.UpdateAsync(id, sliderUpdateDto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await sliderService.DeleteAsync(id));
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<List<SliderReturnDto>>(await sliderService.GetAllAsync()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<SliderReturnDto>(await sliderService.GetByIdAsync(id)));
        }

        
    }
}
