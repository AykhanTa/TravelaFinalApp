using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace TravelaFinalApp.Application.Dtos.GuideDtos
{
    public class GuideCreateDto
    {
        public string FullName { get; set; }
        public string Designation { get; set; }
        public IFormFile File { get; set; }
    }

    public class GuideCreateDtoValidator:AbstractValidator<GuideCreateDto>
    {
        public GuideCreateDtoValidator()
        {
            RuleFor(g=>g.FullName)
                .MinimumLength(5)
                .MaximumLength(30)
                .NotEmpty();

            RuleFor(g => g.Designation)
                .MinimumLength(5)
                .MaximumLength(20)
                .NotEmpty();

            RuleFor(g => g)
           .Custom((g, context) =>
           {
               if (g.File == null)
               {
                   context.AddFailure("File", "not empty");
                   return;
               }
               if (g.File.Length / 1024 > 500)
               {
                   context.AddFailure("File", "size is too large");
               }
               if (!g.File.ContentType.Contains("image/"))
               {
                   context.AddFailure("File", "file must be only imagee");
               }
           });
        }
    }
}
