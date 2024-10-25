using FluentValidation;
using FluentValidation.Validators;

namespace TravelaFinalApp.Application.Dtos.ContactDtos
{
    public class ContactCreateDto
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
    public class ContactCreateDtoValidator : AbstractValidator<ContactCreateDto>
    {
        public ContactCreateDtoValidator()
        {
            RuleFor(a => a.FullName)
                    .NotEmpty()
                    .MinimumLength(5)
                    .MaximumLength(30);

            RuleFor(a => a.Phone)
                .NotEmpty()
                .Matches(@"^\+?[1-9]\d{1,14}$")
                .WithMessage("Phone number must be in a valid format.");

            RuleFor(a => a.Email)
                .NotEmpty()
                .EmailAddress()
                .EmailAddress()
                .WithMessage("Email is not valid.");

            RuleFor(a => a.Subject)
                 .NotEmpty()
                 .MaximumLength(50);

            RuleFor(a => a.Message)
                .NotEmpty()
                .MaximumLength(500);
        }
    }
}
