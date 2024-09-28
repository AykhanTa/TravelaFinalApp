using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TravelaFinalApp.Application.Dtos.SliderDtos;
using TravelaFinalApp.Application.Interfaces;

namespace TravelaFinalApp.Presentation.Controllers.UI
{
    [Route("api/ui/[controller]/[action]")]
    [ApiController]
    public class SliderController(ISliderService sliderService, IMapper _mapper) : ControllerBase
    {
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
