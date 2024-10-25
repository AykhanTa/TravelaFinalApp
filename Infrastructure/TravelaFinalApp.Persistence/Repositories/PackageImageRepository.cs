using TravelaFinalApp.Domain.Entities;
using TravelaFinalApp.Persistence.Data;
using TravelaFinalApp.Persistence.Repositories.Interfaces;

namespace TravelaFinalApp.Persistence.Repositories
{
    public class PackageImageRepository : BaseRepository<PackageImage>, IPackageImageRepository
    {
        public PackageImageRepository(TravelaDbContext context) : base(context)
        {
        }
    }
}
