namespace TravelaFinalApp.Application.Dtos.ContactDtos
{
    public class ContactListDto
    {
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public IEnumerable<ContactReturnDto> Contacts { get; set; } = new List<ContactReturnDto>();
    }
}
