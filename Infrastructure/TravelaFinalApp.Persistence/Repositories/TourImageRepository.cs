using TravelaFinalApp.Domain.Entities;
using TravelaFinalApp.Persistence.Data;
using TravelaFinalApp.Persistence.Repositories.Interfaces;

namespace TravelaFinalApp.Persistence.Repositories
{
    public class TourImageRepository : BaseRepository<TourImage>, ITourImageRepository
    {
        public TourImageRepository(TravelaDbContext context) : base(context)
        {
        }
    }
}
