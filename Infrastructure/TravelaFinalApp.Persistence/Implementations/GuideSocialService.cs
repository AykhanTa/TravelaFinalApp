using AutoMapper;
using TravelaFinalApp.Application.Dtos.GuideDtos;
using TravelaFinalApp.Application.Dtos.GuideSocialDtos;
using TravelaFinalApp.Application.Exceptions;
using TravelaFinalApp.Application.Interfaces;
using TravelaFinalApp.Domain.Entities;
using TravelaFinalApp.Persistence.Repositories.Interfaces;

namespace TravelaFinalApp.Persistence.Implementations
{
    public class GuideSocialService(IGuideSocialRepository guideSocialRepository,IGuideRepository guideRepository,IMapper _mapper) : IGuideSocialService
    {
        public async Task CreateAsync(GuideSocialCreateDto guideSocialCreateDto)
        {
            var data = await guideRepository.GetByIdAsync(guideSocialCreateDto.GuideId);
            if (data == null)
                throw new CustomException("GuideId", "Guide not found");
            var guideSocial=_mapper.Map<GuideSocial>(guideSocialCreateDto);
            await guideSocialRepository.CreateAsync(guideSocial);
            await guideSocialRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existSocial = await guideSocialRepository.GetByIdAsync(id);
            if (existSocial == null)
                throw new CustomException("Id", "Data not found..");
            existSocial.IsDeleted = true;
            await guideSocialRepository.SaveChangesAsync();
        }

        public async Task<List<GuideSocialReturnDto>> GetAllAsync()
        {
            return _mapper.Map<List<GuideSocialReturnDto>>(await guideSocialRepository.GetAllAsync(gs=>!gs.IsDeleted,"Guide"));
        }

        public async Task UpdateAsync(int id, GuideSocialUpdateDto guideSocialUpdateDto)
        {
            var existSocial = await guideSocialRepository.GetByIdAsync(id);
            if (existSocial == null)
                throw new CustomException("Id", "Data not found..");
            _mapper.Map(guideSocialUpdateDto,existSocial);
            await guideSocialRepository.UpdateAsync(existSocial);
            await guideSocialRepository.SaveChangesAsync();

        }
    }
}
