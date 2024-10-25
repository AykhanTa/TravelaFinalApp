using AutoMapper;
using TravelaFinalApp.Application.Dtos.GuideDtos;
using TravelaFinalApp.Application.Exceptions;
using TravelaFinalApp.Application.Helpers;
using TravelaFinalApp.Application.Interfaces;
using TravelaFinalApp.Domain.Entities;
using TravelaFinalApp.Persistence.Repositories.Interfaces;

namespace TravelaFinalApp.Persistence.Implementations
{
    public class GuideService(IGuideRepository guideRepository,IMapper _mapper) : IGuideService
    {
        public async Task CreateAsync(GuideCreateDto guideCreateDto)
        {
            var guide=_mapper.Map<Guide>(guideCreateDto);
            await guideRepository.CreateAsync(guide);
            await guideRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existGuide = await guideRepository.GetEntityAsync(g=>g.Id==id&&!g.IsDeleted,"GuideSocials");
            if (existGuide == null)
                throw new CustomException(404, "Id", "Guide not found..");
            existGuide.IsDeleted = true;
            foreach (var social in existGuide.GuideSocials)
            {
                social.IsDeleted = true;
            }
            await guideRepository.SaveChangesAsync();
        }

        public async Task<List<GuideReturnDto>> GetAllAsync()
        {
            return _mapper.Map<List<GuideReturnDto>>(await guideRepository.GetAllAsync(g=>!g.IsDeleted,"GuideSocials"));
        }

        public async Task<GuideReturnDto> GetByIdAsync(int id)
        {
            var existGuide = await guideRepository.GetEntityAsync(g=>g.Id==id&&!g.IsDeleted, "GuideSocials");
            if (existGuide == null)
                throw new CustomException(404, "Id", "Guide not found..");
            return _mapper.Map<GuideReturnDto>(existGuide);
        }

        public async Task UpdateAsync(int id, GuideUpdateDto guideUpdateDto)
        {
            var existGuide = await guideRepository.GetByIdAsync(id);
            if (existGuide == null)
                throw new CustomException(404,"Id", "Guide not found..");
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", existGuide.Image);
            FileHelper.DeleteFileFromRoute(path);
            _mapper.Map(guideUpdateDto,existGuide);
            await guideRepository.UpdateAsync(existGuide);
            await guideRepository.SaveChangesAsync();
        }
    }
}
