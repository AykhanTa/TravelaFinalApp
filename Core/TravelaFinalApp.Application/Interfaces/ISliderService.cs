using TravelaFinalApp.Application.Dtos.SliderDtos;
using TravelaFinalApp.Domain.Entities;

namespace TravelaFinalApp.Application.Interfaces
{
    public interface ISliderService
    {
        Task<List<Slider>> GetAllAsync();
        Task<Slider> GetByIdAsync(int id);
        Task<int> CreateAsync(SliderCreateDto sliderCreateDto);
        Task<int> DeleteAsync(int id);
        Task<int> UpdateAsync(int id,SliderUpdateDto sliderUpdateDto);
    }
}
