using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelaFinalApp.Application.Dtos.AboutDtos;
using TravelaFinalApp.Application.Interfaces;
using TravelaFinalApp.Persistence.Implementations;

namespace TravelaFinalApp.Presentation.Controllers.UI
{
    [Route("api/ui/[controller]/[action]")]
    [ApiController]
    public class AboutController(IAboutService aboutService,IMapper _mapper) : ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<List<AboutReturnDto>>(await aboutService.GetAllAsync()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if(id>0)
                return Ok(_mapper.Map<AboutReturnDto>(await aboutService.GetByIdAsync(id)));
            return BadRequest("Id can't be zero or negative");
        }
    }
}
