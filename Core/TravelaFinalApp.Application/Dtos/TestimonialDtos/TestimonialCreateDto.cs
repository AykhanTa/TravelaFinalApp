using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace TravelaFinalApp.Application.Dtos.TestimonialDtos
{
    public class TestimonialCreateDto
    {
        public string FullName { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public IFormFile File { get; set; }
    }
    public class TestimonialCreateDtoValidator : AbstractValidator<TestimonialCreateDto>
    {
        public TestimonialCreateDtoValidator()
        {
            RuleFor(t => t.FullName)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(100);

            RuleFor(t => t.Country)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(50);

            RuleFor(t => t.Description)
                .NotEmpty()
                .MinimumLength(30)
                .MaximumLength(150);

            RuleFor(t => t)
            .Custom((t, context) =>
            {
                if (t.File == null)
                {
                    context.AddFailure("File", "not empty");
                    return;
                }
                if (t.File.Length / 1024 > 500)
                {
                    context.AddFailure("File", "size is too large");
                }
                if (!t.File.ContentType.Contains("image/"))
                {
                    context.AddFailure("File", "file must be only imagee");
                }
            });
        }
    }
}
