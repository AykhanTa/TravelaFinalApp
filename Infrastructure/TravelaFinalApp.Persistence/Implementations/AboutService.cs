using AutoMapper;
using TravelaFinalApp.Application.Dtos.AboutDtos;
using TravelaFinalApp.Application.Helpers;
using TravelaFinalApp.Application.Interfaces;
using TravelaFinalApp.Domain.Entities;
using TravelaFinalApp.Persistence.Repositories.Interfaces;

namespace TravelaFinalApp.Persistence.Implementations
{
    public class AboutService(IAboutRepository aboutRepository,IMapper _mapper) : IAboutService
    {
        public async Task CreateAsync(AboutCreateDto aboutCreateDto)
        {
            var about=_mapper.Map<About>(aboutCreateDto);
            await aboutRepository.CreateAsync(about);
            await aboutRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id==null) throw new ArgumentNullException(nameof(id));
            var existAbout=await aboutRepository.GetByIdAsync(id);
            if (existAbout == null)
                throw new NullReferenceException();
            existAbout.IsDeleted= true;
            await aboutRepository.SaveChangesAsync();
        }

        public async Task<List<About>> GetAllAsync()
        {
            return await aboutRepository.GetAllAsync(a=>!a.IsDeleted);
        }

        public async Task<About> GetByIdAsync(int id)
        {
            return await aboutRepository.GetByIdAsync(id);
        }

        public async Task<About> UpdateAsync(int id, AboutUpdateDto aboutUpdateDto)
        {
            var existAbout = await aboutRepository.GetEntityAsync(s => s.Id == id && !s.IsDeleted);
            if (existAbout == null)
                throw new NullReferenceException();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", existAbout.Image);
            FileHelper.DeleteFileFromRoute(path);
            _mapper.Map(aboutUpdateDto, existAbout);
            await aboutRepository.UpdateAsync(existAbout);
            await aboutRepository.SaveChangesAsync();
            return existAbout;
        }
    }
}
