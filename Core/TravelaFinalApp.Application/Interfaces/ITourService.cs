using TravelaFinalApp.Application.Dtos.TourDtos;

namespace TravelaFinalApp.Application.Interfaces
{
    public interface ITourService
    {
        Task<TourListDto> GetAllAsync(int page=1,string? search=null);
        Task<TourDetailDto> GetByIdAsync(int id);
        Task CreateAsync(TourCreateDto tourCreateDto);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id,TourUpdateDto tourUpdateDto);
    }
}
