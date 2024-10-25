using FluentValidation;
using TravelaFinalApp.Application.Extensions;

namespace TravelaFinalApp.Application.Dtos.GetAppointmentDtos
{
    public class GetAppointmentCreateDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime DateTime { get; set; }
        public string Phone { get; set; }
        public string Destination { get; set; }
        public int PersonCount { get; set; }
        public int KidsCount { get; set; }
        public string Content { get; set; }
    }
    public class GetAppointmentCreateDtoValidator : AbstractValidator<GetAppointmentCreateDto>
    {
        public GetAppointmentCreateDtoValidator()
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

            RuleFor(a => a.Destination)
                 .NotEmpty()
                 .MaximumLength(35);

            RuleFor(d => d.PersonCount)
                .NotEmpty()
                .InclusiveBetween(1, 10);

            RuleFor(d => d.KidsCount)
                .InclusiveBetween(0, 4);

            RuleFor(d => d.DateTime)
                .NotEmpty();

            RuleFor(a => a.Content)
                .NotEmpty()
                .MaximumLength(250)
                .Must(ValidatorExtension.NotContainOnlyNumbers).WithMessage("Content can not be only numbers.."); ;
        }
    }
}
