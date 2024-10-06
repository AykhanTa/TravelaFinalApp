using TravelaFinalApp.Application.Dtos.BlogDtos;
using TravelaFinalApp.Application.Dtos.TestimonialDtos;

namespace TravelaFinalApp.Application.Interfaces
{
    public interface IBlogService
    {
        Task<List<BlogReturnDto>> GetAllAsync();
        Task<BlogReturnDto> GetByIdAsync(int id);
        Task CreateAsync(BlogCreateDto blogCreateDto);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id,BlogUpdateDto blogUpdateDto);
    }
}
