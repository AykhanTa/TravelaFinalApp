using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelaFinalApp.Application.Dtos.PackageDtos;
using TravelaFinalApp.Application.Dtos.TourDtos;
using TravelaFinalApp.Application.Exceptions;
using TravelaFinalApp.Application.Extensions;
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
            if (await packageRepository.IsExist(p => p.Title.ToLower() == packageCreateDto.Title.ToLower()))
                throw new CustomException("Title","The same package with same title already exist..");
            if (!await destinationRepository.IsExist(d => d.Id == packageCreateDto.DestinationId && !d.IsDeleted))
                throw new CustomException("Destination", "Destination can't be found");

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
                throw new CustomException("Id", "Id can't be null..");
            var existPackage=await packageRepository.GetByIdAsync(id);
            if (existPackage == null)
                throw new CustomException("Id", "Package can't be found");
            existPackage.IsDeleted=true;
            await packageRepository.SaveChangesAsync();
        }

        public async Task<PackageListDto> GetAllAsync(int page = 1, string search = null)
        {
            var query=_context.Packages.AsQueryable();
            if (search != null)
                query = query.Where(b => b.Title.Contains(search));
            var datas = await query
                .Include(p=>p.Destination)
                .Skip((page - 1) * 3)
                .Take(3)
                .Where(p => !p.IsDeleted)
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
                throw new CustomException("Id", "Id can't be null..");
            return _mapper.Map<PackageReturnDto>(await  packageRepository.GetEntityAsync(p=>p.Id==id&&!p.IsDeleted,"Destination"));
        }

        public Task UpdateAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
