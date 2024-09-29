using TravelaFinalApp.Domain.Entities;
using TravelaFinalApp.Persistence.Data;
using TravelaFinalApp.Persistence.Repositories.Interfaces;

namespace TravelaFinalApp.Persistence.Repositories
{
    public class AboutRepository : BaseRepository<About>, IAboutRepository
    {
        public AboutRepository(TravelaDbContext context) : base(context)
        {
        }
    }
}
