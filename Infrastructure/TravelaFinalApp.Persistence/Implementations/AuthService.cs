using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Web;
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
        ITokenService tokenService,
        IEmailService emailService,
        IMapper _mapper,
        IHttpContextAccessor httpContextAccessor) : IAuthService
    {
        public async Task<RegisterResponse> SignUpAsync(RegisterDto registerDto)
        {
            AppUser? user = await userManager.FindByNameAsync(registerDto.UserName) ?? 
                await userManager.FindByEmailAsync(registerDto.Email);
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

            string token = await userManager.GenerateEmailConfirmationTokenAsync(user);

            string link = $"http://localhost:5039/api/Auth/VerifyEmail?verifyEmail={HttpUtility.UrlEncode(user.Email)}&token={HttpUtility.UrlEncode(token)}";

            //string link = urlHelper.Action(nameof(VerifyEmail), "Auth", new { email = user.Email, token },
            //    httpContextAccessor.HttpContext.Request.Scheme, httpContextAccessor.HttpContext.Request.Host.ToString());

            string body = string.Empty;
            using (StreamReader stream = new StreamReader("wwwroot/templates/verifyEmailTemplate.html"))
            {
                body = stream.ReadToEnd();
            };
            body = body.Replace("{{link}}", link);
            body = body.Replace("{{username}}", user.UserName);

            emailService.SendEmail(new List<string>() { user.Email }, "Verify Email", body);

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

            if (!user.EmailConfirmed)
            {
                return new LoginResponse
                {
                    Success = false,
                    Error = "Login failed: Confirm email!",
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

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await userManager.Users.ToListAsync();
            var userDtos=_mapper.Map<IEnumerable<UserDto>>(users);

            foreach (var userDto in userDtos)
            {
                var roles = await userManager.GetRolesAsync(await userManager.FindByNameAsync(userDto.UserName));
                userDto.Roles=roles.ToList();
            }
            return userDtos;
        }

        public async Task VerifyEmail(string VerifyEmail, string token)
        {
            AppUser user=await userManager.FindByEmailAsync(VerifyEmail);
            if (user == null)
                throw new CustomException("", "User doesn't exist..");
            await userManager.ConfirmEmailAsync(user,token);
        }

        public async Task<ResponseObj> ForgetPassword(string email, string requestScheme, string requestHost)
        {
            AppUser user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return new ResponseObj
                {
                    ResponseMessage = "User does not exist.",
                    StatusCode = (int)StatusCodes.Status400BadRequest
                };
            }

            string token = await userManager.GeneratePasswordResetTokenAsync(user);

            string link = $"http://localhost:5039/api/Auth/ResetPassword??email={HttpUtility.UrlEncode(user.Email)}&token={HttpUtility.UrlEncode(token)}";

            //string link = urlHelper.Action(nameof(VerifyEmail), "Auth", new { email = user.Email, token },
            //    httpContextAccessor.HttpContext.Request.Scheme, httpContextAccessor.HttpContext.Request.Host.ToString());

            string body = string.Empty;
            using (StreamReader stream = new StreamReader("wwwroot/templates/resetPasswordTemplate.html"))
            {
                body = stream.ReadToEnd();
            };
            body = body.Replace("{{link}}", link);
            body = body.Replace("{{username}}", user.UserName);

            emailService.SendEmail(new List<string>() { user.Email }, "Reset Password", body);

            return new ResponseObj
            {
                ResponseMessage = token,
                StatusCode = (int)StatusCodes.Status200OK
            };

        }

        public async Task<ResponseObj> ResetPassword(UserResetPasswordDto userResetPasswordDto)
        {
            AppUser user = await userManager.FindByEmailAsync(userResetPasswordDto.Email);
            if (user == null)
            {
                return new ResponseObj
                {
                    ResponseMessage = "User does not exist.",
                    StatusCode = (int)StatusCodes.Status404NotFound
                };
            }
            var isSucceeded = await userManager.VerifyUserTokenAsync(user, userManager.Options.Tokens.PasswordResetTokenProvider,"ResetPassword",userResetPasswordDto.Token);

            if (!isSucceeded)
            {
                return new ResponseObj
                {
                    ResponseMessage = "Token is not valid!",
                    StatusCode= (int)StatusCodes.Status400BadRequest
                };
            }

            IdentityResult result = await userManager.ResetPasswordAsync(user, userResetPasswordDto.Token, userResetPasswordDto.Password);
            if (!result.Succeeded) return new ResponseObj
            {
                ResponseMessage = string.Join(", ", result.Errors.Select(error => error.Description)),
                StatusCode = (int)StatusCodes.Status400BadRequest
            };

            await userManager.UpdateSecurityStampAsync(user);
            return new ResponseObj
            {
                StatusCode = (int)StatusCodes.Status200OK,
                ResponseMessage = "Password succesfully updated"
            };
        }

        public async Task<ResponseObj> AddRoleAsync(string username, string roleName)
        {
            AppUser user = await userManager.FindByNameAsync(username);
            if (user == null)
            {
                return new ResponseObj
                {
                    ResponseMessage = "User does not exist.",
                    StatusCode = (int)StatusCodes.Status404NotFound
                };
            }

            if(!await roleManager.RoleExistsAsync(roleName))
            {
                return new ResponseObj
                {
                    ResponseMessage = "Role doesn't exist",
                    StatusCode = (int)StatusCodes.Status400BadRequest
                };
            }
            var userRoles = await userManager.GetRolesAsync(user);
            if(userRoles.Any(r=>r.Equals(roleName,StringComparison.OrdinalIgnoreCase)))
            {
                return new ResponseObj
                {
                    ResponseMessage = $"User already have {roleName} role..",
                    StatusCode = (int)StatusCodes.Status400BadRequest

                };
            }

            var result = await userManager.AddToRoleAsync(user, roleName);
            if (!result.Succeeded)
            {
                return new ResponseObj
                {
                    ResponseMessage = string.Join(", ", result.Errors.Select(error => error.Description)),
                    StatusCode = (int)StatusCodes.Status400BadRequest
                };
            }

            return new ResponseObj
            {
                ResponseMessage = $"Role '{roleName}' added to user '{username}' successfully.",
                StatusCode = (int)StatusCodes.Status200OK
            };


        }

        public async Task<ResponseObj> RemoveRoleAsync(string username, string roleName)
        {
            AppUser user = await userManager.FindByNameAsync(username);
            if (user == null)
            {
                return new ResponseObj
                {
                    ResponseMessage = "User does not exist.",
                    StatusCode = (int)StatusCodes.Status404NotFound
                };
            }

            if (!await roleManager.RoleExistsAsync(roleName))
            {
                return new ResponseObj
                {
                    ResponseMessage = "Role doesn't exist",
                    StatusCode = (int)StatusCodes.Status400BadRequest
                };
            }
            if (roleName.Equals("Member", StringComparison.OrdinalIgnoreCase))
            {
                return new ResponseObj
                {
                    ResponseMessage = "'Member' role can't be remove.",
                    StatusCode = (int)StatusCodes.Status400BadRequest
                };
            }
            var result=await userManager.RemoveFromRoleAsync(user, roleName);
            if (!result.Succeeded)
            {
                return new ResponseObj
                {
                    ResponseMessage = string.Join(", ", result.Errors.Select(error => error.Description)),
                    StatusCode = (int)StatusCodes.Status400BadRequest
                };
            }

            return new ResponseObj
            {
                ResponseMessage = $"Role '{roleName}' removed from user '{username}' successfully.",
                StatusCode = (int)StatusCodes.Status200OK
            };
        }
    }
}
