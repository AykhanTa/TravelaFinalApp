using TravelaFinalApp.Application.Dtos.ContactDtos;

namespace TravelaFinalApp.Application.Interfaces
{
    public interface IContactService
    {
        Task<ContactListDto> GetAllAsync(int page = 1, string? search = null);
        Task<ContactReturnDto> GetByIdAsync(int id);
        Task CreateAsync(ContactCreateDto contactCreateDto);
        Task DeleteAsync(int id);
    }
}
