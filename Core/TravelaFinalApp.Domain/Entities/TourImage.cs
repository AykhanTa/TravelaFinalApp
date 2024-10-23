namespace TravelaFinalApp.Domain.Entities
{
    public class TourImage:BaseEntity
    {
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public int TourId { get; set; }
        public Tour Tour { get; set; }
    }
}
