using TravelaFinalApp.Application.Dtos.CategoryDtos;

namespace TravelaFinalApp.Application.Dtos.TourDtos
{
    public class TourReturnDto
    {
        public int Id { get; set; }
        public string Place { get; set; }
        public int Price { get; set; }
        public int DiscountPercent { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public int DestinationId { get; set; }
        public DestinationInTourReturnDto Destination { get; set; }
        public IEnumerable<CategoryReturnDto> Categories { get; set; }

    }
    public class DestinationInTourReturnDto
    {
        public string DestinationPlace { get; set; }
    }
}
