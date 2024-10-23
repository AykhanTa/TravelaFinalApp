using Microsoft.Extensions.Configuration;
using TravelaFinalApp.Domain.Entities;

namespace TravelaFinalApp.Application.Interfaces
{
    public interface ITokenService
    {
        string GetToken(IList<string> userRoles,AppUser user,IConfiguration config); 
    }
}
