using AutoMapper;
using TravelaFinalApp.Application.Dtos.DestinationDtos;
using TravelaFinalApp.Application.Exceptions;
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
            if (await destinationRepository.IsExist(d => d.DestinationPlace.ToLower().Trim() == destinationCreateDto.DestinationPlace.ToLower().Trim()))
                throw new CustomException(400, "DestinationPlace", $" '{destinationCreateDto.DestinationPlace}' - with same name destination already exist!!");
            var destination= _mapper.Map<Destination>(destinationCreateDto);
            await destinationRepository.CreateAsync(destination);
            await destinationRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existDestination=await destinationRepository.GetByIdAsync(id);
            if (existDestination == null)
                throw new CustomException(404, "Id", "Data not found..");
            existDestination.IsDeleted=true;
            await destinationRepository.SaveChangesAsync();
        }

        public async Task<List<DestinationReturnDto>> GetAllAsync()
        {
            return _mapper.Map<List<DestinationReturnDto>>(await destinationRepository.GetAllAsync(d=>!d.IsDeleted));
        }

        public async Task<DestinationReturnDto> GetByIdAsync(int id)
        {
            var existDestination = await destinationRepository.GetByIdAsync(id);
            if (existDestination == null)
                throw new CustomException(404, "Id", "Data not found..");
            return _mapper.Map<DestinationReturnDto>(existDestination);
        }

        public async Task UpdateAsync(int id, DestinationUpdateDto destinationUpdateDto)
        {
            var existDestination = await destinationRepository.GetByIdAsync(id);
            if (existDestination == null)
                throw new CustomException(404, "Id", "Data not found..");
            if (await destinationRepository.IsExist(d => d.DestinationPlace.ToLower().Trim() == destinationUpdateDto.DestinationPlace.ToLower().Trim()))
                throw new CustomException(400, "DestinationPlace", $" '{destinationUpdateDto.DestinationPlace}' - with same name destination already exist!!");
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", existDestination.MainImage);
            FileHelper.DeleteFileFromRoute(path);
            _mapper.Map(destinationUpdateDto, existDestination);
            await destinationRepository.UpdateAsync(existDestination);
            await destinationRepository.SaveChangesAsync();
        }
    }
}
