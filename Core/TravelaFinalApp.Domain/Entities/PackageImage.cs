namespace TravelaFinalApp.Domain.Entities
{
    public class PackageImage:BaseEntity
    {
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public int PackageId { get; set; }
        public Package Package { get; set; }
    }
}
