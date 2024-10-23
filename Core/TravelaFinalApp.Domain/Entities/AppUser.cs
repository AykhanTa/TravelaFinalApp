using Microsoft.AspNetCore.Identity;

namespace TravelaFinalApp.Domain.Entities
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }
    }
}
