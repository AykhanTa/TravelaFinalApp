using TravelaFinalApp.Application.Dtos.ServiceDtos;
using TravelaFinalApp.Application.Dtos.TestimonialDtos;

namespace TravelaFinalApp.Application.Interfaces
{
    public interface ITestimonialService
    {
        Task<TestimonialListDto> GetAllAsync(int page=1,string search=null);
        Task<TestimonialReturnDto> GetByIdAsync(int id);
        Task CreateAsync(TestimonialCreateDto testimonialCreateDto);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id,TestimonialUpdateDto testimonialUpdateDto);
    }
}
