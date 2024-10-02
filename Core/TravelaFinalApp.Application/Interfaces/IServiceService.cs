using TravelaFinalApp.Application.Dtos.ServiceDtos;
using TravelaFinalApp.Application.Dtos.SliderDtos;
using TravelaFinalApp.Domain.Entities;

namespace TravelaFinalApp.Application.Interfaces
{
    public interface IServiceService
    {
        Task<List<ServiceReturnDto>> GetAllAsync();
        Task<ServiceReturnDto> GetByIdAsync(int id);
        Task CreateAsync(ServiceCreateDto serviceCreateDto);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id,ServiceUpdateDto serviceUpdateDto);
    }
}
