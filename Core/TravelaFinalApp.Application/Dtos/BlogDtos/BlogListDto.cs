namespace TravelaFinalApp.Application.Dtos.BlogDtos
{
    public class BlogListDto
    {
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public List<BlogReturnDto> Blogs { get; set; }
    }
}
