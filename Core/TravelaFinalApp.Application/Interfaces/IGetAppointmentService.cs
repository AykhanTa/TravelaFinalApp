using TravelaFinalApp.Application.Dtos.ContactDtos;
using TravelaFinalApp.Application.Dtos.GetAppointmentDtos;

namespace TravelaFinalApp.Application.Interfaces
{
    public interface IGetAppointmentService
    {
        Task<GetAppointmentListDto> GetAllAsync(int page = 1, string? search = null);
        Task<GetAppointmentReturnDto> GetByIdAsync(int id);
        Task CreateAsync(GetAppointmentCreateDto getAppointmentCreateDto);
        Task DeleteAsync(int id);
    }
}
