using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelaFinalApp.Application.Dtos.BlogDtos;
using TravelaFinalApp.Application.Exceptions;
using TravelaFinalApp.Application.Helpers;
using TravelaFinalApp.Application.Interfaces;
using TravelaFinalApp.Domain.Entities;
using TravelaFinalApp.Persistence.Data;
using TravelaFinalApp.Persistence.Repositories.Interfaces;

namespace TravelaFinalApp.Persistence.Implementations
{
    public class BlogService(IBlogRepository blogRepository,TravelaDbContext _context,IMapper _mapper) : IBlogService
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
                throw new CustomException("Id", "Blog not found.");
            existBlog.IsDeleted = true;
            await blogRepository.SaveChangesAsync();
        }      
               
        public async Task<BlogListDto> GetAllAsync(int page = 1, string search = null)
        {
            var query=_context.Blogs.AsQueryable();
            if(search != null)
                query=query.Where(b=>b.Title.Contains(search));
            var datas = await query
                .Skip((page - 1) * 3)
                .Take(3)
                .Where(t => !t.IsDeleted)
                .ToListAsync();
            var totalCount=await query.CountAsync();

            BlogListDto blogListDto = new();
            blogListDto.TotalCount = totalCount;
            blogListDto.CurrentPage=page;
            blogListDto.Blogs=_mapper.Map<List<BlogReturnDto>>(datas);
            return  blogListDto;
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
