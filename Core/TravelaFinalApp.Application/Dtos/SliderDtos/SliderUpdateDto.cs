using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace TravelaFinalApp.Application.Dtos.SliderDtos
{
    public class SliderUpdateDto
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public IFormFile File { get; set; }
    }
    public class SliderUpdateDtoValidator : AbstractValidator<SliderUpdateDto>
    {
        public SliderUpdateDtoValidator()
        {
            RuleFor(s => s.Title)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(100);

            RuleFor(s => s.SubTitle)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(100);

            RuleFor(s => s.Description)
                .NotEmpty()
                .MinimumLength(30)
                .MaximumLength(150);

            RuleFor(s => s)
            .Custom((s, context) =>
            {
                if (s.File == null)
                {
                    context.AddFailure("File", "not empty");
                    return;
                }
                if (s.File.Length / 1024 > 500)
                {
                    context.AddFailure("File", "size is too large");
                }
                if (!s.File.ContentType.Contains("image/"))
                {
                    context.AddFailure("File", "file must be only imagee");
                }
            });

        }
    }
}
