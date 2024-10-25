using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelaFinalApp.Application.Dtos.TestimonialDtos;
using TravelaFinalApp.Application.Exceptions;
using TravelaFinalApp.Application.Helpers;
using TravelaFinalApp.Application.Interfaces;
using TravelaFinalApp.Domain.Entities;
using TravelaFinalApp.Persistence.Data;
using TravelaFinalApp.Persistence.Repositories;
using TravelaFinalApp.Persistence.Repositories.Interfaces;

namespace TravelaFinalApp.Persistence.Implementations
{
    public class TestimonialService(ITestimonialRepository testimonialRepository,IMapper _mapper,TravelaDbContext _context) : ITestimonialService
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
                throw new CustomException(404, "Id", "Data not found..");
            existTestimonial.IsDeleted= true;   
            await testimonialRepository.SaveChangesAsync();
        }

        public async Task<TestimonialListDto> GetAllAsync(int page = 1, string search = null)
        {
            var query = _context.Testimonials.Where(t=>!t.IsDeleted).AsQueryable();
            if (search != null)
                query = query.Where(b => b.FullName.Contains(search));
            var datas = await query
                .Skip((page - 1) * 3)
                .Take(3)
                .ToListAsync();
            var totalCount = await query.CountAsync();

            TestimonialListDto testimonialListDto = new();
            testimonialListDto.TotalCount= totalCount;
            testimonialListDto.CurrentPage = page;
            testimonialListDto.Testimonials=_mapper.Map<List<TestimonialReturnDto>>(datas);

            return testimonialListDto;
        }

        public async Task<TestimonialReturnDto> GetByIdAsync(int id)
        {
            var existTestimonial = await testimonialRepository.GetByIdAsync(id);
            if (existTestimonial == null)
                throw new CustomException(404, "Id", "Data not found.");
            return _mapper.Map<TestimonialReturnDto>(existTestimonial);
        }

        public async Task UpdateAsync(int id, TestimonialUpdateDto testimonialUpdateDto)
        {
            var existTestimonial = await testimonialRepository.GetByIdAsync(id);
            if (existTestimonial == null)
                throw new CustomException(404, "Id", "Data not found..");
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", existTestimonial.Image);
            FileHelper.DeleteFileFromRoute(path);
            _mapper.Map(testimonialUpdateDto, existTestimonial);
            await testimonialRepository.UpdateAsync(existTestimonial);
            await testimonialRepository.SaveChangesAsync();
        }
    }
}
