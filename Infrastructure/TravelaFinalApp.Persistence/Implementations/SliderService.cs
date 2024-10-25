using AutoMapper;
using TravelaFinalApp.Application.Dtos.SliderDtos;
using TravelaFinalApp.Application.Exceptions;
using TravelaFinalApp.Application.Helpers;
using TravelaFinalApp.Application.Interfaces;
using TravelaFinalApp.Domain.Entities;
using TravelaFinalApp.Persistence.Repositories.Interfaces;

namespace TravelaFinalApp.Persistence.Implementations
{
    public class SliderService(ISliderRepository sliderRepository,IMapper _mapper) : ISliderService
    {
        public async Task CreateAsync(SliderCreateDto sliderCreateDto)
        {
            var slider = _mapper.Map<Slider>(sliderCreateDto);
            slider.CreateDate=DateTime.Now;
            await sliderRepository.CreateAsync(slider);
            await sliderRepository.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var existSlider=await sliderRepository.GetEntityAsync(s => !s.IsDeleted && s.Id == id);
            if (existSlider == null)
                throw new CustomException(404, "Id", "Data not found");
            existSlider.IsDeleted = true;
            await sliderRepository.SaveChangesAsync();
        }

        public async Task<List<Slider>> GetAllAsync()
        {
            return await sliderRepository.GetAllAsync(s=>!s.IsDeleted);
        }

        public async Task<Slider> GetByIdAsync(int id)
        {
            var existSlider = await sliderRepository.GetByIdAsync(id);
            if (existSlider == null)
                throw new CustomException(404, "Id", "Data not found");
           return existSlider;
        }

        public async Task UpdateAsync(int id,SliderUpdateDto sliderUpdateDto)
        {
            var existSlider = await sliderRepository.GetEntityAsync(s => s.Id == id && !s.IsDeleted);
            if (existSlider == null)
                throw new CustomException(404,"Id", "Data not found");
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", existSlider.Image);
            FileHelper.DeleteFileFromRoute(path);
            _mapper.Map(sliderUpdateDto, existSlider);
            await sliderRepository.UpdateAsync(existSlider);
            await sliderRepository.SaveChangesAsync();
        }
    }
}
