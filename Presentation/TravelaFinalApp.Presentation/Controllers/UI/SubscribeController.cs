using Microsoft.AspNetCore.Mvc;
using TravelaFinalApp.Application.Dtos.SubscribeDtos;
using TravelaFinalApp.Application.Interfaces;

namespace TravelaFinalApp.Presentation.Controllers.UI
{
    [Route("api/ui/[controller]/[action]")]
    [ApiController]
    public class SubscribeController(ISubscribeService subscribeService) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> Create(SubscribeCreateDto subscribeCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            await subscribeService.AddSubscribeAsync(subscribeCreateDto);
            return CreatedAtAction(nameof(Create), new { Response = "You are successfully subscribed.." });
        }
    }
}
