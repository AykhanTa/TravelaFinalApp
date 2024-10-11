using FluentValidation;

namespace TravelaFinalApp.Application.Dtos.SubscribeDtos
{
    public class SubscribeCreateDto
    {
        public string Email { get; set; }
    }
    public class SubscribeCreateDtoValidator : AbstractValidator<SubscribeCreateDto>
    {
        public SubscribeCreateDtoValidator()
        {
            RuleFor(s=>s.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
        }
    }

}
