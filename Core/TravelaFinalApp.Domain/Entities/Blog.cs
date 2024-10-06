namespace TravelaFinalApp.Domain.Entities
{
    public class Blog:BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public string Image { get; set; }
    }
}
