using TravelaFinalApp.Domain.Entities;

namespace TravelaFinalApp.Application.Dtos.GuideSocialDtos
{
    public class GuideSocialReturnDto
    {
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Linkedin { get; set; }
        public int GuideId { get; set; }
        public GuideInGuideSocialReturnDto Guide { get; set; }
    }
    public class GuideInGuideSocialReturnDto
    {
        public string FullName { get; set; }
        public string Designation { get; set; }
    }
}
