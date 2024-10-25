using TravelaFinalApp.Application.Dtos.CategoryDtos;
using TravelaFinalApp.Domain.Entities;

namespace TravelaFinalApp.Application.Dtos.TourDtos
{
    public class TourDetailDto
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
        public IEnumerable<CategoryInTourDetailDto> Categories { get; set; }
        public List<TourImageInTourDetailDto> TourImages { get; set; }
    }

    public class CategoryInTourDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class TourImageInTourDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsMain { get; set; }
    }
}
