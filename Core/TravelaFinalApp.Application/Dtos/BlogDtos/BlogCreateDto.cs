using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace TravelaFinalApp.Application.Dtos.BlogDtos
{
    public class BlogCreateDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public IFormFile File { get; set; }
    }
    public class BlogCreateDtoValidator : AbstractValidator<BlogCreateDto>
    {
        public BlogCreateDtoValidator()
        {
            RuleFor(b => b.Title)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(30);

            RuleFor(b => b.Author)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(50);

            RuleFor(b => b.Content)
                .NotEmpty()
                .MinimumLength(30)
                .MaximumLength(150);

            RuleFor(b => b)
            .Custom((b, context) =>
            {
                if (b.File == null)
                {
                    context.AddFailure("File", "not empty");
                    return;
                }
                if (b.File.Length / 1024 > 500)
                {
                    context.AddFailure("File", "size is too large");
                }
                if (!b.File.ContentType.Contains("image/"))
                {
                    context.AddFailure("File", "file must be only imagee");
                }
            });
        }
    }
}
