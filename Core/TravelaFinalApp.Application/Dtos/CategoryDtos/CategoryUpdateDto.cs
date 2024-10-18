using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace TravelaFinalApp.Application.Dtos.CategoryDtos
{
    public class CategoryUpdateDto
    {
        public string Name { get; set; }
        public IFormFile File { get; set; }
    }
    public class CategoryUpdateDtoValidator : AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateDtoValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .MinimumLength(7)
                .MaximumLength(30);

            RuleFor(c => c)
            .Custom((c, context) =>
            {
                if (c.File == null)
                {
                    context.AddFailure("File", "not empty");
                    return;
                }
                if (c.File.Length / 1024 > 500)
                {
                    context.AddFailure("File", "size is too large");
                }
                if (!c.File.ContentType.Contains("image/"))
                {
                    context.AddFailure("File", "file must be only imagee");
                }
            });
        }
    }
}
