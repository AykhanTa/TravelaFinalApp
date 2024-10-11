using TravelaFinalApp.Application.Dtos.ServiceDtos;
using TravelaFinalApp.Application.Dtos.SettingDtos;

namespace TravelaFinalApp.Application.Interfaces
{
    public interface ISettingService
    {
        Task<List<SettingReturnDto>> GetAllAsync();
        Task CreateAsync(SettingCreateDto settingCreateDto);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, SettingUpdateDto settingUpdateDto);
    }
}
