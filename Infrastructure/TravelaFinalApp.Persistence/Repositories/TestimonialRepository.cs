using TravelaFinalApp.Domain.Entities;
using TravelaFinalApp.Persistence.Data;
using TravelaFinalApp.Persistence.Repositories.Interfaces;

namespace TravelaFinalApp.Persistence.Repositories
{
    public class TestimonialRepository : BaseRepository<Testimonial>, ITestimonialRepository
    {
        public TestimonialRepository(TravelaDbContext context) : base(context)
        {
        }
    }
}
