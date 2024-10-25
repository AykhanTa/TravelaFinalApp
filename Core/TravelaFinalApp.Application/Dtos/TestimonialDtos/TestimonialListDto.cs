namespace TravelaFinalApp.Application.Dtos.TestimonialDtos
{
    public class TestimonialListDto
    {
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public List<TestimonialReturnDto> Testimonials { get; set; }
    }
}
