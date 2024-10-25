using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelaFinalApp.Application.Dtos.CategoryDtos;
using TravelaFinalApp.Application.Interfaces;

namespace TravelaFinalApp.Presentation.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class CategoryController(ICategoryService categoryService) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> Create(CategoryCreateDto categoryCreateDto)
        {
            await categoryService.CreateAsync(categoryCreateDto);
            return CreatedAtAction(nameof(Create), new { Response = "Data created successfully.." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            await categoryService.DeleteAsync(id);
            return Ok(new {Response="Data deleted successfully.."});
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute]int id,CategoryUpdateDto categoryUpdateDto)
        {
            await categoryService.UpdateAsync(id, categoryUpdateDto);
            return Ok(new { Response = "Data updated successfully.." });

        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await categoryService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            return Ok(await categoryService.GetByIdAsync(id));
        }



    }
}
