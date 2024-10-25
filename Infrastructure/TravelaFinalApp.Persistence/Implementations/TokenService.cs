using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TravelaFinalApp.Application.Interfaces;
using TravelaFinalApp.Domain.Entities;

namespace TravelaFinalApp.Persistence.Implementations
{
    public class TokenService : ITokenService
    {
        public string GetToken(IList<string> userRoles, AppUser user,IConfiguration config)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:SecretKey"]));


            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim("FullName",user.FullName),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Email,user.Email),

            };
            claims.AddRange(userRoles.Select(r => new Claim(ClaimTypes.Role, r)).ToList());
            var audience = config.GetSection("Jwt:Audience").Value;
            var issuer = config.GetSection("Jwt:Issuer").Value;

            var secToken = new JwtSecurityToken(
                issuer,
              audience,
              claims,
              expires: DateTime.Now.AddMinutes(5),
              signingCredentials: credentials);

            return  new JwtSecurityTokenHandler().WriteToken(secToken);

        }
    }
}
