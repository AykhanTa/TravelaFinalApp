using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace TravelaFinalApp.Application.Dtos.DestinationDtos
{
    public class DestinationUpdateDto
    {
        public string DestinationPlace { get; set; }
        public IFormFile File { get; set; }
    }
    public class DestinationUpdateDtoValidator : AbstractValidator<DestinationUpdateDto>
    {
        public DestinationUpdateDtoValidator()
        {
            RuleFor(d => d.DestinationPlace)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(20);

            RuleFor(d => d)
            .Custom((d, context) =>
            {
                if (d.File == null)
                {
                    context.AddFailure("File", "not empty");
                    return;
                }
                if (d.File.Length / 1024 > 500)
                {
                    context.AddFailure("File", "size is too large");
                }
                if (!d.File.ContentType.Contains("image/"))
                {
                    context.AddFailure("File", "file must be only imagee");
                }
            });
        }
    }
}
