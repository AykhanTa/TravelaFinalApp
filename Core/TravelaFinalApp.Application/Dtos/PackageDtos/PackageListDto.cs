namespace TravelaFinalApp.Application.Dtos.PackageDtos
{
    public class PackageListDto
    {
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public List<PackageReturnDto> Packages { get; set; }
    }
}
