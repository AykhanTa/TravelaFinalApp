namespace TravelaFinalApp.Domain.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public List<TourCategory> TourCategories { get; set; }
    }
}
