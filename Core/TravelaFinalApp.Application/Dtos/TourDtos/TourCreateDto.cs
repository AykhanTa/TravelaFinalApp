using FluentValidation;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using TravelaFinalApp.Application.Extensions;
using TravelaFinalApp.Domain.Entities;

namespace TravelaFinalApp.Application.Dtos.TourDtos
{
    public class TourCreateDto
    {
        public required string Place { get; set; }
        public int Price { get; set; }
        public int DiscountPercent { get; set; }

        public required string Content { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public int DestinationId { get; set; }
        public required List<int> CategoryIds { get; set; }

        public List<IFormFile> UploadImages { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public List<TourImage>? TourImages { get; set; }
    }
    public class TourCreateDtoValidator : AbstractValidator<TourCreateDto>
    {
        public TourCreateDtoValidator()
        {
            RuleFor(s=>s.Place)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(40);

            RuleFor(s=>s.Price)
                .NotEmpty()
                .InclusiveBetween(1,9999);

            RuleFor(s => s.DiscountPercent)
                .InclusiveBetween(0, 100);

            RuleFor(s => s.Content)
                .NotEmpty()
                .MinimumLength(50)
                .MaximumLength(200)
                .Must(ValidatorExtension.NotContainOnlyNumbers).WithMessage("Content can not be only numbers..");

            RuleFor(s => s.Date)
                .NotEmpty();

            RuleFor(s => s.Duration)
                .NotEmpty()
                .InclusiveBetween(1, 30);

        }
    }
}
