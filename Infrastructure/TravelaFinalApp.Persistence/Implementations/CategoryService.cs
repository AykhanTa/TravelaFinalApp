using AutoMapper;
using TravelaFinalApp.Application.Dtos.CategoryDtos;
using TravelaFinalApp.Application.Exceptions;
using TravelaFinalApp.Application.Helpers;
using TravelaFinalApp.Application.Interfaces;
using TravelaFinalApp.Domain.Entities;
using TravelaFinalApp.Persistence.Repositories.Interfaces;

namespace TravelaFinalApp.Persistence.Implementations
{
    public class CategoryService(ICategoryRepository categoryRepository,IMapper _mapper) : ICategoryService
    {
        public async Task CreateAsync(CategoryCreateDto categoryCreateDto)
        {
            if (!await categoryRepository.IsExist(c => c.Name.ToLower() == categoryCreateDto.Name.ToLower()))
                throw new CustomException("Name", $"{categoryCreateDto.Name} category already exist..");
            var category=_mapper.Map<Category>(categoryCreateDto);
            await categoryRepository.CreateAsync(category);
            await categoryRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existCategory=await categoryRepository.GetByIdAsync(id);
            if (existCategory == null)
                throw new CustomException("Id", "Data not found..");
            existCategory.IsDeleted = true;
            await categoryRepository.SaveChangesAsync();
        }

        public async Task<List<CategoryReturnDto>> GetAllAsync()
        {
            return _mapper.Map<List<CategoryReturnDto>>(await categoryRepository.GetAllAsync(c=>!c.IsDeleted));
        }

        public async Task<CategoryReturnDto> GetByIdAsync(int id)
        {
            var existCategory = await categoryRepository.GetEntityAsync(c => c.Id == id&&!c.IsDeleted);
            if (existCategory == null)
                throw new CustomException("Id", "Data not found..");
            return _mapper.Map<CategoryReturnDto>(existCategory);
        }

        public async Task UpdateAsync(int id, CategoryUpdateDto categoryUpdateDto)
        {
            var existCategory = await categoryRepository.GetByIdAsync(id);
            if (existCategory == null)
                throw new CustomException("Id", "Data not found..");
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", existCategory.Image);
            FileHelper.DeleteFileFromRoute(path);
            _mapper.Map(categoryUpdateDto, existCategory);
            await categoryRepository.UpdateAsync(existCategory);
            await categoryRepository.SaveChangesAsync();
        }
    }
}
