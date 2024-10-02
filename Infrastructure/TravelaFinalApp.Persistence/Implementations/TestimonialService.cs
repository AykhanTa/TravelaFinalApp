using AutoMapper;
using TravelaFinalApp.Application.Dtos.TestimonialDtos;
using TravelaFinalApp.Application.Helpers;
using TravelaFinalApp.Application.Interfaces;
using TravelaFinalApp.Domain.Entities;
using TravelaFinalApp.Persistence.Repositories.Interfaces;

namespace TravelaFinalApp.Persistence.Implementations
{
    public class TestimonialService(ITestimonialRepository testimonialRepository,IMapper _mapper) : ITestimonialService
    {
        public async Task CreateAsync(TestimonialCreateDto testimonialCreateDto)
        {
            var testimonial= _mapper.Map<Testimonial>(testimonialCreateDto);
            await testimonialRepository.CreateAsync(testimonial);
            await testimonialRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existTestimonial=await testimonialRepository.GetByIdAsync(id);
            if (existTestimonial == null)
                throw new NullReferenceException("Testimonial not found");
            existTestimonial.IsDeleted= true;
            await testimonialRepository.SaveChangesAsync();
        }

        public async Task<List<TestimonialReturnDto>> GetAllAsync()
        {
            return _mapper.Map<List<TestimonialReturnDto>>(await testimonialRepository.GetAllAsync(t=>!t.IsDeleted));
        }

        public async Task<TestimonialReturnDto> GetByIdAsync(int id)
        {
            return _mapper.Map<TestimonialReturnDto>(await testimonialRepository.GetByIdAsync(id));
        }

        public async Task UpdateAsync(int id, TestimonialUpdateDto testimonialUpdateDto)
        {
            var existTestimonial = await testimonialRepository.GetByIdAsync(id);
            if (existTestimonial == null)
                throw new NullReferenceException("Testimonial not found");
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", existTestimonial.Image);
            FileHelper.DeleteFileFromRoute(path);
            _mapper.Map(testimonialUpdateDto, existTestimonial);
            await testimonialRepository.UpdateAsync(existTestimonial);
            await testimonialRepository.SaveChangesAsync();
        }
    }
}
