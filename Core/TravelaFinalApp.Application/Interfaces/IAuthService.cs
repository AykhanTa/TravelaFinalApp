using TravelaFinalApp.Application.Dtos.UserDtos;
using TravelaFinalApp.Application.Helpers.Account;

namespace TravelaFinalApp.Application.Interfaces
{
    public interface IAuthService
    {
        Task<RegisterResponse> SignUpAsync(RegisterDto registerDto);
        Task<LoginResponse> SignInAsync(LoginDto loginDto);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task VerifyEmail(string VerifyEmail, string token);
        Task<ResponseObj> ForgetPassword(string email, string requestScheme, string requestHost);
        Task<ResponseObj> ResetPassword(UserResetPasswordDto userResetPasswordDto);
        Task<ResponseObj> AddRoleAsync(string username, string roleName);
        Task<ResponseObj> RemoveRoleAsync(string username, string roleName);
    }
}
