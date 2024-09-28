using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelaFinalApp.Application.Dtos.SliderDtos;
using TravelaFinalApp.Application.Helpers;
using TravelaFinalApp.Application.Interfaces;
using TravelaFinalApp.Domain.Entities;
using TravelaFinalApp.Persistence.Data;
using TravelaFinalApp.Persistence.Repositories.Interfaces;

namespace TravelaFinalApp.Persistence.Implementations
{
    public class SliderService(ISliderRepository sliderRepository,IMapper _mapper) : ISliderService
    {
        public async Task<int> CreateAsync(SliderCreateDto sliderCreateDto)
        {
            var slider = _mapper.Map<Slider>(sliderCreateDto);
            slider.CreateDate=DateTime.Now;
            await sliderRepository.CreateAsync(slider);
            await sliderRepository.SaveChangesAsync();
            return 1;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var existSlider=await sliderRepository.GetEntityAsync(s => !s.IsDeleted && s.Id == id);
            if (existSlider == null)
                return 0;
            existSlider.IsDeleted = true;
            await sliderRepository.SaveChangesAsync();
            return existSlider.Id;
        }

        public async Task<List<Slider>> GetAllAsync()
        {
            return await sliderRepository.GetAllAsync(s=>!s.IsDeleted);
        }

        public async Task<Slider> GetByIdAsync(int id)
        {
           return await sliderRepository.GetByIdAsync(id);
        }

        public async Task<int> UpdateAsync(int id,SliderUpdateDto sliderUpdateDto)
        {
            var existSlider = await sliderRepository.GetEntityAsync(s => s.Id == id && !s.IsDeleted);
            if (existSlider==null)
                return 0;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", existSlider.Image);
            FileHelper.DeleteFileFromRoute(path);
            _mapper.Map(sliderUpdateDto, existSlider);
            await sliderRepository.SaveChangesAsync();
            return existSlider.Id;
        }
    }
}
