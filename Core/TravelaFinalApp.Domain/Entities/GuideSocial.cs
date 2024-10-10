namespace TravelaFinalApp.Domain.Entities
{
    public class GuideSocial:BaseEntity
    {
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Linkedin { get; set; }
        public int GuideId { get; set; }
        public Guide Guide { get; set; }

    }
}
