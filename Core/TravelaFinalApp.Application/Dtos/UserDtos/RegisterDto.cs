using FluentValidation;

namespace TravelaFinalApp.Application.Dtos.UserDtos
{
    public class RegisterDto
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
    }
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(r => r.FullName)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(30);

            RuleFor(r => r.UserName)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(20);

            RuleFor(r => r.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(r => r.Password)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(20);

            RuleFor(r => r.RePassword)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(20);

            RuleFor(r => r)
                .Custom((r, context) =>
                {
                    if (r.Password != r.RePassword)
                    {
                        context.AddFailure("Password", "Password and RePassword doesn't match..");
                    }
                });

        }
    }
}
