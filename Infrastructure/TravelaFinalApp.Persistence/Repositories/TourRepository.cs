using Microsoft.EntityFrameworkCore;
using TravelaFinalApp.Application.Dtos.TourDtos;
using TravelaFinalApp.Domain.Entities;
using TravelaFinalApp.Persistence.Data;
using TravelaFinalApp.Persistence.Repositories.Interfaces;

namespace TravelaFinalApp.Persistence.Repositories
{
    public class TourRepository : BaseRepository<Tour>, ITourRepository
    {
        private readonly TravelaDbContext _context;
        public TourRepository(TravelaDbContext context) : base(context)
        {
            
            _context=context;
        }

        public async Task<List<Tour>> GetAllWithIncludesAsync()
        {
            return await _context.Tours.Where(t=>!t.IsDeleted).Include(t=>t.Destination).Include(t => t.TourCategories).ThenInclude(t => t.Category).ToListAsync();
        }

        public async Task<Tour> GetByIdWithIncludesAsync(int id)
        {
            return await _context.Tours.Include(t=>t.Destination).Include(t=>t.TourImages).Include(t=>t.TourCategories).ThenInclude(t=>t.Category).FirstOrDefaultAsync(t => t.Id == id && !t.IsDeleted);
        }
    }
}
