namespace TravelaFinalApp.Domain.Entities
{
    public class Package:BaseEntity
    {
        public string Title { get; set; }
        public int Duration { get; set; }
        public int PersonCount { get; set; }
        public double Price { get; set; }
        public bool HotelDeals { get; set; }
        public string Content { get; set; }
        public int DestinationId { get; set; }
        public Destination Destination { get; set; }
        public List<PackageImage> PackageImages { get; set; }
    }
}
