using Microsoft.EntityFrameworkCore;
using TravelaFinalApp.Domain.Entities;
using TravelaFinalApp.Persistence.Data;
using TravelaFinalApp.Persistence.Repositories.Interfaces;

namespace TravelaFinalApp.Persistence.Repositories
{
    public class GuideSocialRepository : BaseRepository<GuideSocial>, IGuideSocialRepository
    {
        public GuideSocialRepository(TravelaDbContext context) : base(context)
        {
        }
    }
}
