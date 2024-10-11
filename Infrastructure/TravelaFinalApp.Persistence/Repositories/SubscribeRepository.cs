using TravelaFinalApp.Domain.Entities;
using TravelaFinalApp.Persistence.Data;
using TravelaFinalApp.Persistence.Repositories.Interfaces;

namespace TravelaFinalApp.Persistence.Repositories
{
    public class SubscribeRepository : BaseRepository<Subscribe>, ISubscribeRepository
    {
        public SubscribeRepository(TravelaDbContext context) : base(context)
        {
        }
    }
}
