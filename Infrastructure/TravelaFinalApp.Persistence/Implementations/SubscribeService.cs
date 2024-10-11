using AutoMapper;
using TravelaFinalApp.Application.Dtos.SubscribeDtos;
using TravelaFinalApp.Application.Exceptions;
using TravelaFinalApp.Application.Interfaces;
using TravelaFinalApp.Domain.Entities;
using TravelaFinalApp.Persistence.Repositories.Interfaces;

namespace TravelaFinalApp.Persistence.Implementations
{
    public class SubscribeService(ISubscribeRepository subscribeRepository,IMapper _mapper) : ISubscribeService
    {
        public async Task AddSubscribeAsync(SubscribeCreateDto subscribeCreateDto)
        {
            if (await subscribeRepository.IsExist(s => s.Email == subscribeCreateDto.Email))
                throw new CustomException("Email", "You are already subscribed..");
            var subscribe = _mapper.Map<Subscribe>(subscribeCreateDto);
            await subscribeRepository.CreateAsync(subscribe);
            await subscribeRepository.SaveChangesAsync();
        }

        public async Task<List<SubscribeReturnDto>> GetAllAsync()
        {
            return _mapper.Map<List<SubscribeReturnDto>>(await subscribeRepository.GetAllAsync());
        }
    }
}
