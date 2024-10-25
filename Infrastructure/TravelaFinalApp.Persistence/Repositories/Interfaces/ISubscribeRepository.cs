using TravelaFinalApp.Domain.Entities;

namespace TravelaFinalApp.Persistence.Repositories.Interfaces
{
    public interface ISubscribeRepository:IBaseRepository<Subscribe>
    {
        Task<List<string>> GetSubscribedEmailsAsync();
    }
}
