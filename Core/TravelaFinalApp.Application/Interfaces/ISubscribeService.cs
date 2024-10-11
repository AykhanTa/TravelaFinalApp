using TravelaFinalApp.Application.Dtos.SubscribeDtos;

namespace TravelaFinalApp.Application.Interfaces
{
    public interface ISubscribeService
    {
        Task AddSubscribeAsync(SubscribeCreateDto subscribeCreateDto);
        Task<List<SubscribeReturnDto>> GetAllAsync(); 
    }
}
