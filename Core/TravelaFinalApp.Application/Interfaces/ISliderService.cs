using TravelaFinalApp.Application.Dtos.SliderDtos;
using TravelaFinalApp.Domain.Entities;

namespace TravelaFinalApp.Application.Interfaces
{
    public interface ISliderService
    {
        Task<List<Slider>> GetAllAsync();
        Task<Slider> GetByIdAsync(int id);
        Task CreateAsync(SliderCreateDto sliderCreateDto);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id,SliderUpdateDto sliderUpdateDto);
    }
}
