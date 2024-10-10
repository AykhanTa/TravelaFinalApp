using TravelaFinalApp.Application.Dtos.GuideDtos;
using TravelaFinalApp.Application.Dtos.GuideSocialDtos;

namespace TravelaFinalApp.Application.Interfaces
{
    public interface IGuideSocialService
    {
        Task<List<GuideSocialReturnDto>> GetAllAsync();
        Task CreateAsync(GuideSocialCreateDto guideSocialCreateDto);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, GuideSocialUpdateDto guideSocialUpdateDto);
    }
}
