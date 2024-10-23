using TravelaFinalApp.Application.Dtos.UserDtos;
using TravelaFinalApp.Application.Helpers.Account;

namespace TravelaFinalApp.Application.Interfaces
{
    public interface IAuthService
    {
        Task<RegisterResponse> SignUpAsync(RegisterDto registerDto);
        Task<LoginResponse> SignInAsync(LoginDto loginDto);
        //Task<IEnumerable<RegisterDto>> GetAllUsersAsync();
        //Task<UserDto> GetUserByUserNameAsync(string userName);
        //Task VerifyEmail(string VerifyEmail, string token);
        //Task ForgetPassword(string email, string requestScheme, string requestHost);
        //Task ResetPassword(UserResetPasswordDto userResetPasswordDto);
        //Task AddRoleAsync(string username, string roleName);
        //Task RemoveRoleAsync(string username, string roleName);
    }
}
