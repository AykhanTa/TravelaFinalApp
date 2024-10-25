using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelaFinalApp.Application.Dtos.TourDtos;
using TravelaFinalApp.Application.Exceptions;
using TravelaFinalApp.Application.Extensions;
using TravelaFinalApp.Application.Helpers;
using TravelaFinalApp.Application.Interfaces;
using TravelaFinalApp.Domain.Entities;
using TravelaFinalApp.Persistence.Data;
using TravelaFinalApp.Persistence.Repositories.Interfaces;

namespace TravelaFinalApp.Persistence.Implementations
{
    public class TourService(ITourRepository tourRepository,
        IDestinationRepository destinationRepository,
        ICategoryRepository categoryRepository,
        ITourCategoryRepository tourCategoryRepository,
        ITourImageRepository tourImageRepository,
        IMapper _mapper,
        TravelaDbContext _context) : ITourService
    {
        public async Task CreateAsync(TourCreateDto tourCreateDto)
        {
            if (!await destinationRepository.IsExist(d => d.Id == tourCreateDto.DestinationId && !d.IsDeleted))
                throw new CustomException("DestinationId",$"{tourCreateDto.DestinationId} destination can't be found..");

            var tour = _mapper.Map<Tour>(tourCreateDto);


            List<TourImage> images = new();

            foreach (var item in tourCreateDto.UploadImages)
            {
                var fileName=item.Save(Directory.GetCurrentDirectory(),"images");

                images.Add(new TourImage { Name = fileName,Tour=tour});
            }

            images.FirstOrDefault().IsMain = true;

            foreach (var tourImage in images)
            {
                tourImageRepository.CreateAsync(tourImage);
            }

            tour.TourImages = images;

            foreach (int id in tourCreateDto.CategoryIds)
            {
                if(!await categoryRepository.IsExist(c => c.Id == id && !c.IsDeleted))
                {
                    throw new CustomException("CategoryIds", $"{id} category can't be found");
                }
                await tourCategoryRepository.CreateAsync(new TourCategory
                {
                    CategoryId=id,
                    Tour=tour
                });
            }
            await tourRepository.CreateAsync(tour);
            await tourRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existTour = await tourRepository.GetEntityAsync(t=>t.Id==id&&!t.IsDeleted,"TourImages","TourCategories");
            if (existTour == null)
                throw new CustomException("Id", "Tour can't be found..");
            existTour.IsDeleted = true;
            foreach (var tourImage in existTour.TourImages)
            {
                tourImage.IsDeleted = true;
            }
            foreach (var tourCategory in existTour.TourCategories)
            {
                tourCategory.IsDeleted = true;
            }
            await tourRepository.SaveChangesAsync();
            await tourCategoryRepository.SaveChangesAsync();
            await tourImageRepository.SaveChangesAsync();
        }

        public async Task<TourListDto> GetAllAsync(int page = 1, string? search = null)
        {
            var query = _context.Tours.AsQueryable().Where(t=>!t.IsDeleted);
            if (search != null)
                query = query.Where(t => t.Place.Contains(search)&&!t.IsDeleted);
            var datas = await query
                .Include(t=>t.TourCategories).ThenInclude(m=>m.Category)
                .Include(t=>t.Destination)
                .Include(t=>t.TourImages)
                .Skip((page - 1) * 3)
                .Take(3)
                .Where(t => !t.IsDeleted)
                .ToListAsync();
            var totalCount = await query.CountAsync();

            TourListDto tourListDto = new();
            tourListDto.TotalCount=totalCount;
            tourListDto.CurrentPage=page;
            tourListDto.Tours = _mapper.Map<List<TourReturnDto>>(datas);

            return tourListDto;

        }

        public async Task<TourDetailDto> GetByIdAsync(int id)
        {
            var existTour=await tourRepository.GetByIdWithIncludesAsync(id);
            if (existTour == null)
                throw new CustomException("Id", "Tour can't be found..");
            return  _mapper.Map<TourDetailDto>(existTour);
        }

        public async Task UpdateAsync(int id, TourUpdateDto tourUpdateDto)
        {
            if (id == null)
                throw new CustomException("Id", "Id can't  be null..");
            var existTour = await tourRepository.GetByIdWithIncludesAsync(id);
            if (existTour == null)
                throw new CustomException("Id", "Tour can't be found..");

            foreach (var tourImage in existTour.TourImages)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", tourImage.Name);
                FileHelper.DeleteFileFromRoute(path);
                tourImage.IsDeleted = true;
            }

            foreach (var tourCategory in existTour.TourCategories)
            {
                tourCategory.IsDeleted = true;
            }

            foreach (int tourId in tourUpdateDto.CategoryIds)
            {
                if (!await categoryRepository.IsExist(c => c.Id == tourId && !c.IsDeleted))
                {
                    throw new CustomException("CategoryIds", $"{id} category can't be found");
                }
                await tourCategoryRepository.CreateAsync(new TourCategory
                {
                    CategoryId = id,
                    Tour = existTour
                });
            }
            _mapper.Map(tourUpdateDto,existTour);

            List<TourImage> images = new();

            foreach (var item in tourUpdateDto.UploadImages)
            {
                var fileName = item.Save(Directory.GetCurrentDirectory(), "images");

                images.Add(new TourImage { Name = fileName, Tour = existTour });
            }

            images.FirstOrDefault().IsMain = true;

            foreach (var tourImage in images)
            {
               await tourImageRepository.CreateAsync(tourImage);
            }

            existTour.TourImages = images;

            await tourRepository.UpdateAsync(existTour);
            await tourRepository.SaveChangesAsync();
            await tourCategoryRepository.SaveChangesAsync();
            await tourImageRepository.SaveChangesAsync();
        }

    }
}
