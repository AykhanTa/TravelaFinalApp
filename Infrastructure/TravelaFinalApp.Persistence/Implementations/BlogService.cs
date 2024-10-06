using AutoMapper;
using TravelaFinalApp.Application.Dtos.BlogDtos;
using TravelaFinalApp.Application.Helpers;
using TravelaFinalApp.Application.Interfaces;
using TravelaFinalApp.Domain.Entities;
using TravelaFinalApp.Persistence.Repositories.Interfaces;

namespace TravelaFinalApp.Persistence.Implementations
{
    public class BlogService(IBlogRepository blogRepository,IMapper _mapper) : IBlogService
    {
        public async Task CreateAsync(BlogCreateDto dto)
        {      
            var blog=_mapper.Map<Blog>(dto);
            await blogRepository.CreateAsync(blog);
            await blogRepository.SaveChangesAsync();
        }      
               
        public async Task DeleteAsync(int id)
        {
            var existBlog = await blogRepository.GetByIdAsync(id);
            if (existBlog == null)
                throw new NullReferenceException("Blog is not found..");
            existBlog.IsDeleted = true;
            await blogRepository.SaveChangesAsync();
        }      
               
        public async Task<List<BlogReturnDto>> GetAllAsync()
        {
            return  _mapper.Map<List<BlogReturnDto>>(await blogRepository.GetAllAsync(b=>!b.IsDeleted));
        }

        public async Task<BlogReturnDto> GetByIdAsync(int id)
        {
            return _mapper.Map<BlogReturnDto>(await blogRepository.GetByIdAsync(id));
        }

        public async Task UpdateAsync(int id,BlogUpdateDto blogUpdateDto)
        {
            var existBlog = await blogRepository.GetByIdAsync(id);
            if (existBlog == null)
                throw new NullReferenceException("Blog is not found..");
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", existBlog.Image);
            FileHelper.DeleteFileFromRoute(path);
            _mapper.Map(blogUpdateDto,existBlog);
            await blogRepository.UpdateAsync(existBlog);
            await blogRepository.SaveChangesAsync();
        }
    }
}
