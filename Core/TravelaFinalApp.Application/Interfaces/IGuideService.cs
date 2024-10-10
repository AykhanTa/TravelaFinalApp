using TravelaFinalApp.Application.Dtos.GuideDtos;
using TravelaFinalApp.Application.Dtos.ServiceDtos;
using TravelaFinalApp.Application.Dtos.TestimonialDtos;

namespace TravelaFinalApp.Application.Interfaces
{
    public interface IGuideService
    {
        Task<List<GuideReturnDto>> GetAllAsync();
        Task<GuideReturnDto> GetByIdAsync(int id);
        Task CreateAsync(GuideCreateDto guideCreateDto);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, GuideUpdateDto guideUpdateDto);

    }
}
