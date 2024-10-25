using AutoMapper;
using TravelaFinalApp.Application.Dtos.ServiceDtos;
using TravelaFinalApp.Application.Exceptions;
using TravelaFinalApp.Application.Interfaces;
using TravelaFinalApp.Domain.Entities;
using TravelaFinalApp.Persistence.Repositories.Interfaces;

namespace TravelaFinalApp.Persistence.Implementations
{
    public class ServiceService(IServiceRepository serviceRepository,IMapper _mapper) : IServiceService
    {
        public async Task CreateAsync(ServiceCreateDto serviceCreateDto)
        {
            var service = _mapper.Map<Service>(serviceCreateDto);
            await serviceRepository.CreateAsync(service);
            await serviceRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existService = await serviceRepository.GetByIdAsync(id);
            if (existService == null)
                throw new CustomException(404, "Id", "Data not found..");
            existService.IsDeleted = true;
            await serviceRepository.SaveChangesAsync();
        }

        public async Task<List<ServiceReturnDto>> GetAllAsync()
        {
            return _mapper.Map<List<ServiceReturnDto>>(await serviceRepository.GetAllAsync(s=>!s.IsDeleted));
        }

        public async Task<ServiceReturnDto> GetByIdAsync(int id)
        {
            var existService = await serviceRepository.GetByIdAsync(id);
            if (existService == null)
                throw new CustomException(404, "Id", "Service not found..");
            return _mapper.Map<ServiceReturnDto>(existService);
        }

        public async Task UpdateAsync(int id, ServiceUpdateDto serviceUpdateDto)
        {
            var existService= await serviceRepository.GetByIdAsync(id);
            if (existService == null)
                throw new CustomException(404,"Id","Service not found..");
            _mapper.Map(serviceUpdateDto,existService);
            await serviceRepository.UpdateAsync(existService);
            await serviceRepository.SaveChangesAsync();            
        }
    }
}
