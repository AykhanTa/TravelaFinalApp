using AutoMapper;
using TravelaFinalApp.Application.Dtos.ServiceDtos;
using TravelaFinalApp.Application.Dtos.SettingDtos;
using TravelaFinalApp.Application.Exceptions;
using TravelaFinalApp.Application.Interfaces;
using TravelaFinalApp.Domain.Entities;
using TravelaFinalApp.Persistence.Repositories.Interfaces;

namespace TravelaFinalApp.Persistence.Implementations
{
    public class SettingService(ISettingRepository settingRepository,IMapper _mapper) : ISettingService
    {
        public async Task CreateAsync(SettingCreateDto settingCreateDto)
        {
            var setting=_mapper.Map<Setting>(settingCreateDto);
            await settingRepository.CreateAsync(setting);
            await settingRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existSetting = await settingRepository.GetByIdAsync(id);
            if (existSetting == null)
                throw new CustomException("Id", "Data not found..");
            existSetting.IsDeleted = true;
            await settingRepository.SaveChangesAsync();
        }

        public async Task<List<SettingReturnDto>> GetAllAsync()
        {
            return _mapper.Map<List<SettingReturnDto>>(await settingRepository.GetAllAsync(s=>!s.IsDeleted));
        }

        public async Task UpdateAsync(int id,SettingUpdateDto settingUpdateDto)
        {
            var existSetting=await settingRepository.GetByIdAsync(id);
            if (existSetting == null)
                throw new CustomException("Id", "Data not found..");
            _mapper.Map(settingUpdateDto,existSetting);
            await settingRepository.UpdateAsync(existSetting);
            await settingRepository.SaveChangesAsync();
        }
    }
}
