using TravelaFinalApp.Application.Dtos.AboutDtos;
using TravelaFinalApp.Application.Dtos.SliderDtos;
using TravelaFinalApp.Domain.Entities;

namespace TravelaFinalApp.Application.Interfaces
{
    public interface IAboutService
    {
        Task<List<About>> GetAllAsync();
        Task<About> GetByIdAsync(int id);
        Task CreateAsync(AboutCreateDto aboutCreateDto);
        Task DeleteAsync(int id);
        Task<About> UpdateAsync(int id, AboutUpdateDto aboutUpdateDto);
    }
}
