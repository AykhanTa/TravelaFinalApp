using TravelaFinalApp.Application.Dtos.CategoryDtos;
using TravelaFinalApp.Domain.Entities;

namespace TravelaFinalApp.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryReturnDto>> GetAllAsync();
        Task<CategoryReturnDto> GetByIdAsync(int id);
        Task CreateAsync(CategoryCreateDto categoryCreateDto);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, CategoryUpdateDto categoryUpdateDto);
    }
}
