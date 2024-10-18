namespace TravelaFinalApp.Domain.Entities
{
    public class Tour:BaseEntity
    {
        public string Place { get; set; }
        public int Price { get; set; }
        public int DiscountPercent{ get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public int DestinationId { get; set; }
        public Destination Destination { get; set; }
        public List<TourCategory> TourCategories { get; set; }
    }
}
