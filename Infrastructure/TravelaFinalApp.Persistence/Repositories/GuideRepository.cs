using TravelaFinalApp.Domain.Entities;
using TravelaFinalApp.Persistence.Data;
using TravelaFinalApp.Persistence.Repositories.Interfaces;

namespace TravelaFinalApp.Persistence.Repositories
{
    public class GuideRepository : BaseRepository<Guide>, IGuideRepository
    {
        public GuideRepository(TravelaDbContext context) : base(context)
        {
        }
    }
}
