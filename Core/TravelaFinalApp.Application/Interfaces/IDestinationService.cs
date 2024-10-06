using TravelaFinalApp.Application.Dtos.BlogDtos;
using TravelaFinalApp.Application.Dtos.DestinationDtos;

namespace TravelaFinalApp.Application.Interfaces
{
    public interface IDestinationService
    {
        Task<List<DestinationReturnDto>> GetAllAsync();
        Task<DestinationReturnDto> GetByIdAsync(int id);
        Task CreateAsync(DestinationCreateDto destinationCreateDto);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, DestinationUpdateDto destinationUpdateDto);

    }
}
