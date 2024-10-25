using Microsoft.EntityFrameworkCore;
using TravelaFinalApp.Domain.Entities;
using TravelaFinalApp.Persistence.Data;
using TravelaFinalApp.Persistence.Repositories.Interfaces;

namespace TravelaFinalApp.Persistence.Repositories
{
    public class SubscribeRepository : BaseRepository<Subscribe>, ISubscribeRepository
    {
        private readonly TravelaDbContext _context;
        public SubscribeRepository(TravelaDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<string>> GetSubscribedEmailsAsync() =>
             await _context.Subscribes
            .Where(s => !s.IsDeleted)
            .Select(s => s.Email)
            .ToListAsync();

    }
}
