using TravelaFinalApp.Application.Dtos.TourDtos;
using TravelaFinalApp.Domain.Entities;

namespace TravelaFinalApp.Persistence.Repositories.Interfaces
{
    public interface ITourRepository:IBaseRepository<Tour>
    {
        Task <List<Tour>> GetAllWithIncludesAsync();
        Task <Tour> GetByIdWithIncludesAsync(int id);
    }
}
