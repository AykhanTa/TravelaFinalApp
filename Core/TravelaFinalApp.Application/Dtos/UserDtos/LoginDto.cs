using FluentValidation;

namespace TravelaFinalApp.Application.Dtos.UserDtos
{
    public class LoginDto
    {
        public string EmailOrUsername { get; set; }
        public string Password { get; set; }
    }
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(l=>l.EmailOrUsername)
                .NotEmpty();

            RuleFor(l => l.Password)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(20);
        }
    }
}
