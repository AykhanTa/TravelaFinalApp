using FluentValidation;

namespace TravelaFinalApp.Application.Dtos.ServiceDtos
{
    public class ServiceCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public class ServiceCreateDtoValidator : AbstractValidator<ServiceCreateDto>
    {
        public ServiceCreateDtoValidator()
        {
            RuleFor(s => s.Title)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(100);

            RuleFor(s => s.Description)
                .NotEmpty()
                .MinimumLength(30)
                .MaximumLength(200);

            RuleFor(s => s.Icon)
                .NotEmpty();
        }
    }
}
