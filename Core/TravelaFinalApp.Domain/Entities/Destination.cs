namespace TravelaFinalApp.Domain.Entities
{
    public class Destination:BaseEntity
    {
        public string DestinationPlace { get; set; }
        public string MainImage { get; set; }
        public List<Tour> Tour { get; set; }
    }
}
