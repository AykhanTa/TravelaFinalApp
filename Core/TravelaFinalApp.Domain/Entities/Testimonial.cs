namespace TravelaFinalApp.Domain.Entities
{
    public class Testimonial:BaseEntity
    {
        public string FullName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Country { get; set; }
    }
}
