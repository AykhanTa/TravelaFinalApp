namespace TravelaFinalApp.Domain.Entities
{
    public class TourCategory
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public Tour Tour { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
