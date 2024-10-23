using TravelaFinalApp.Domain.Entities;
using TravelaFinalApp.Persistence.Data;
using TravelaFinalApp.Persistence.Repositories.Interfaces;

namespace TravelaFinalApp.Persistence.Repositories
{
    public class TourCategoryRepository : BaseRepository<TourCategory>, ITourCategoryRepository
    {
        public TourCategoryRepository(TravelaDbContext context) : base(context)
        {
        }
    }
}
