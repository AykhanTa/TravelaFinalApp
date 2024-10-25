using TravelaFinalApp.Domain.Entities;

namespace TravelaFinalApp.Application.Dtos.GetAppointmentDtos
{
    public class GetAppointmentListDto
    {
        public int CurrentPage { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<GetAppointmentReturnDto> GetAppointments { get; set; }=new List<GetAppointmentReturnDto>();
    }
}
