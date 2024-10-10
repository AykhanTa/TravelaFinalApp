namespace TravelaFinalApp.Domain.Entities
{
    public class Guide : BaseEntity
    {
        public string FullName { get; set; }
        public string Designation { get; set; }
        public string Image { get; set; }
        public List<GuideSocial> GuideSocials { get; set; }
    }
}
