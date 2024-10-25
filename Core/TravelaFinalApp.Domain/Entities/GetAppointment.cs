namespace TravelaFinalApp.Domain.Entities
{
    public class GetAppointment:BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime DateTime { get; set; }
        public string Phone { get; set; }
        public string Destination { get; set; }
        public int PersonCount { get; set; }
        public int KidsCount { get; set; }
        public string Content { get; set; }
    }
}
