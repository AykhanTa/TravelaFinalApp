using AutoMapper;
using TravelaFinalApp.Application.Dtos.DestinationDtos;
using TravelaFinalApp.Application.Helpers;
using TravelaFinalApp.Application.Interfaces;
using TravelaFinalApp.Domain.Entities;
using TravelaFinalApp.Persistence.Repositories.Interfaces;

namespace TravelaFinalApp.Persistence.Implementations
{
    public class DestinationService(IDestinationRepository destinationRepository,IMapper _mapper) : IDestinationService
    {
        public async Task CreateAsync(DestinationCreateDto destinationCreateDto)
        {
            var destination= _mapper.Map<Destination>(destinationCreateDto);
            await destinationRepository.CreateAsync(destination);
            await destinationRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existDestination=await destinationRepository.GetByIdAsync(id);
            if (existDestination == null)
                throw new NullReferenceException("Destination is not found..");
            existDestination.IsDeleted=true;
            await destinationRepository.SaveChangesAsync();
        }

        public async Task<List<DestinationReturnDto>> GetAllAsync()
        {
            return _mapper.Map<List<DestinationReturnDto>>(await destinationRepository.GetAllAsync());
        }

        public async Task<DestinationReturnDto> GetByIdAsync(int id)
        {
            return _mapper.Map<DestinationReturnDto>(await destinationRepository.GetByIdAsync(id));
        }

        public async Task UpdateAsync(int id, DestinationUpdateDto destinationUpdateDto)
        {
            var existDestination = await destinationRepository.GetByIdAsync(id);
            if (existDestination == null)
                throw new NullReferenceException("Destination is not found..");
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", existDestination.MainImage);
            FileHelper.DeleteFileFromRoute(path);
            _mapper.Map(destinationUpdateDto, existDestination);
            await destinationRepository.UpdateAsync(existDestination);
            await destinationRepository.SaveChangesAsync();
        }
    }
}
