using TravelaFinalApp.Application.Dtos.PackageDtos;
using TravelaFinalApp.Application.Dtos.TourDtos;

namespace TravelaFinalApp.Application.Interfaces
{
    public interface IPackageService
    {
        Task<PackageListDto> GetAllAsync(int page=1,string search=null);
        Task<PackageReturnDto> GetByIdAsync(int id);
        Task CreateAsync(PackageCreateDto packageCreateDto);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id);
    }
}
