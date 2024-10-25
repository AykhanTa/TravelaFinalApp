namespace TravelaFinalApp.Application.Dtos.PackageDtos
{
    public class PackageReturnDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public int PersonCount { get; set; }
        public double Price { get; set; }
        public bool HotelDeals { get; set; }
        public string Content { get; set; }
        public int DestinationId { get; set; }
        public DestinationInPackageReturnDto Destination { get; set; }
    }
    public class DestinationInPackageReturnDto
    {
        public string DestinationPlace { get; set; }
    }
}
