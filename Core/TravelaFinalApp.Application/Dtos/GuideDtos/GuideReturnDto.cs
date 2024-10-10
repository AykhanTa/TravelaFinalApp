namespace TravelaFinalApp.Application.Dtos.GuideDtos
{
    public class GuideReturnDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Designation { get; set; }
        public string Image { get; set; }
        public List<GuideSocialsInGuideReturnDto> GuideSocials { get; set; }
    }
    public class GuideSocialsInGuideReturnDto
    {
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Linkedin { get; set; }
    }
}
