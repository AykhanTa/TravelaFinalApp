namespace TravelaFinalApp.Application.Dtos.TourDtos
{
    public class TourListDto
    {
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public IEnumerable<TourReturnDto> Tours { get; set; } = new List<TourReturnDto>();
    }
}
