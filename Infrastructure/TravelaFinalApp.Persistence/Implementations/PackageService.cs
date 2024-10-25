using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TravelaFinalApp.Application.Dtos.PackageDtos;
using TravelaFinalApp.Application.Dtos.TourDtos;
using TravelaFinalApp.Application.Exceptions;
using TravelaFinalApp.Application.Extensions;
using TravelaFinalApp.Application.Helpers;
using TravelaFinalApp.Application.Interfaces;
using TravelaFinalApp.Domain.Entities;
using TravelaFinalApp.Persistence.Data;
using TravelaFinalApp.Persistence.Repositories;
using TravelaFinalApp.Persistence.Repositories.Interfaces;

namespace TravelaFinalApp.Persistence.Implementations
{
    public class PackageService(IPackageRepository packageRepository,
        IDestinationRepository destinationRepository,
        IPackageImageRepository packageImageRepository,
        IMapper _mapper,
        TravelaDbContext _context) : IPackageService
    {
        public async Task CreateAsync(PackageCreateDto packageCreateDto)
        {
            if (await packageRepository.IsExist(p => p.Title.ToLower().Trim() == packageCreateDto.Title.ToLower().Trim()))
                throw new CustomException(400,"Title","The same package with same title already exist..");
            if (!await destinationRepository.IsExist(d => d.Id == packageCreateDto.DestinationId && !d.IsDeleted))
                throw new CustomException(404,"Destination", "Destination can't be found");

            var package=_mapper.Map<Package>(packageCreateDto);
            
            List<PackageImage> images = new();

            foreach (var item in packageCreateDto.UploadImages)
            {
                var fileName = item.Save(Directory.GetCurrentDirectory(), "images");

                images.Add(new PackageImage { Name = fileName, Package = package });
            }

            images.FirstOrDefault().IsMain = true;

            foreach (var packageImage in images)
            {
                packageImageRepository.CreateAsync(packageImage);
            }

            package.PackageImages = images;
            await packageRepository.CreateAsync(package);
            await packageRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id == null)
                throw new CustomException(400,"Id", "Id can't be null..");
            var existPackage=await packageRepository.GetByIdAsync(id);
            if (existPackage == null)
                throw new CustomException(404,"Id", "Package can't be found");
            existPackage.IsDeleted=true;
            await packageRepository.SaveChangesAsync();
        }

        public async Task<PackageListDto> GetAllAsync(int page = 1, string search = null)
        {
            var query=_context.Packages.Where(p=>!p.IsDeleted).AsQueryable();
            if (search != null)
                query = query.Where(b => b.Title.Trim().Contains(search.Trim()));
            var datas = await query
                .Include(p=>p.Destination)
                .Skip((page - 1) * 3)
                .Take(3)
                .ToListAsync();
            var totalCount = await query.CountAsync();

            PackageListDto packageListDto = new();
            packageListDto.TotalCount=totalCount;
            packageListDto.CurrentPage=page;
            packageListDto.Packages = _mapper.Map<List<PackageReturnDto>>(datas);

            return packageListDto;
        }

        public async Task<PackageReturnDto> GetByIdAsync(int id)
        {
            if (id == null)
                throw new CustomException(400,"Id", "Id can't be null..");
            var existPackage = await packageRepository.GetEntityAsync(p => p.Id == id && !p.IsDeleted, "Destination");
            if (existPackage == null)
                throw new CustomException(404, "Id", "Data not found..");
            return _mapper.Map<PackageReturnDto>(existPackage);
        }

        public async Task UpdateAsync(int id, PackageUpdateDto packageUpdateDto)
        {
            if (id == null)
                throw new CustomException(400, "Id", "Id can't  be null..");
            var existPackage = await packageRepository.GetEntityAsync(p=>p.Id==id,"PackageImages","Destination");
            if (existPackage == null)
                throw new CustomException(404, "Id", "Package can't be found..");

            if (await packageRepository.IsExist(p => p.Title.ToLower().Trim() == packageUpdateDto.Title.ToLower().Trim()&&p.Id!=existPackage.Id))
                throw new CustomException(400, "Title", "The same package with same title already exist..");

            if (!await destinationRepository.IsExist(d => d.Id == packageUpdateDto.DestinationId && !d.IsDeleted))
                throw new CustomException(404, "Destination", "Destination can't be found");

            foreach (var packageImage in existPackage.PackageImages)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", packageImage.Name);
                FileHelper.DeleteFileFromRoute(path);
                packageImage.IsDeleted = true;
            }

            List<PackageImage> images = new();

            foreach (var item in packageUpdateDto.UploadImages)
            {
                var fileName = item.Save(Directory.GetCurrentDirectory(), "images");

                images.Add(new PackageImage { Name = fileName, PackageId = existPackage.Id });
            }

            images.FirstOrDefault().IsMain = true;

            foreach (var packageImage in images)
            {
                await packageImageRepository.CreateAsync(packageImage);
            }
            await packageImageRepository.SaveChangesAsync();


            _mapper.Map(packageUpdateDto, existPackage);


            await packageRepository.UpdateAsync(existPackage);
            await packageRepository.SaveChangesAsync();

        }
    }
}
