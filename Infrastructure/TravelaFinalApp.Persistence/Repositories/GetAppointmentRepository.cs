using TravelaFinalApp.Domain.Entities;
using TravelaFinalApp.Persistence.Data;
using TravelaFinalApp.Persistence.Repositories.Interfaces;

namespace TravelaFinalApp.Persistence.Repositories
{
    public class GetAppointmentRepository : BaseRepository<GetAppointment>, IGetAppointmentRepository
    {
        public GetAppointmentRepository(TravelaDbContext context) : base(context)
        {
        }
    }
}
