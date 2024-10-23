using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TravelaFinalApp.Application.Dtos.UserDtos;
using TravelaFinalApp.Application.Exceptions;
using TravelaFinalApp.Application.Helpers.Account;
using TravelaFinalApp.Application.Interfaces;
using TravelaFinalApp.Domain.Entities;

namespace TravelaFinalApp.Persistence.Implementations
{
    public class AuthService(UserManager<AppUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IConfiguration _configuration,
        ITokenService tokenService) : IAuthService
    {
        public async Task<RegisterResponse> SignUpAsync(RegisterDto registerDto)
        {
            AppUser user = await userManager.FindByNameAsync(registerDto.UserName);
            if (user != null)
                throw new CustomException("UserName", $"{registerDto.UserName} with userName already exist..");
            user = new()
            {
                FullName = registerDto.FullName,
                UserName = registerDto.UserName,
                Email = registerDto.Email,
            };

            IdentityResult result = await userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                return new RegisterResponse
                {
                    Success = false,
                    ResponseMessage = result.Errors.Select(e => e.Description)
                };
            }
            await userManager.AddToRoleAsync(user, "Member");

            return new RegisterResponse
            {
                Success = true
            };
        }

        public async Task<LoginResponse> SignInAsync(LoginDto loginDto)
        {
           /* AppUser?*/  var user = await userManager.FindByEmailAsync(loginDto.EmailOrUsername) ??
                await userManager.FindByNameAsync(loginDto.EmailOrUsername);

            if (user == null)
            {
                return new LoginResponse
                {
                    Success = false,
                    Error = "Login failed: User not found",
                    Token = null
                };
            }
            var result = await userManager.CheckPasswordAsync(user,loginDto.Password);
            if (!result)
            {
                return new LoginResponse
                {
                    Success = false,
                    Error = "Login failed: Password or Username incorrect!",
                    Token = null
                };
            }

            var userRoles = await userManager.GetRolesAsync(user);

            return new LoginResponse
            {
                Success = true,
                Error = null,
                Token = tokenService.GetToken(userRoles, user, _configuration)
            };


        }
    }
}
