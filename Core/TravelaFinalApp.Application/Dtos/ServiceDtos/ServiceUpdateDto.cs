using FluentValidation;

namespace TravelaFinalApp.Application.Dtos.ServiceDtos
{
    public class ServiceUpdateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
    public class ServiceUpdateDtoValidator : AbstractValidator<ServiceUpdateDto>
    {
        public ServiceUpdateDtoValidator()
        {
            RuleFor(s => s.Title)
                .MinimumLength(5)
                .MaximumLength(100);

            RuleFor(s => s.Description)
                .MinimumLength(30)
                .MaximumLength(200);
        }
    }
}
