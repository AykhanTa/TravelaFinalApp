using FluentValidation;
using Microsoft.AspNetCore.Http;
using TravelaFinalApp.Application.Extensions;

namespace TravelaFinalApp.Application.Dtos.PackageDtos
{
    public class PackageUpdateDto
    {
        public string Title { get; set; }
        public int Duration { get; set; }
        public int PersonCount { get; set; }
        public double Price { get; set; }
        public bool HotelDeals { get; set; }
        public string Content { get; set; }
        public int DestinationId { get; set; }
        public List<IFormFile> UploadImages { get; set; }
    }
    public class PackageUpdateDtoValidator : AbstractValidator<PackageUpdateDto>
    {
        public PackageUpdateDtoValidator()
        {
            RuleFor(s => s.Title)
               .NotEmpty()
               .MinimumLength(3)
               .MaximumLength(40);

            RuleFor(s => s.Price)
                .NotEmpty()
                .InclusiveBetween(1, 9999);

            RuleFor(s => s.PersonCount)
                .NotEmpty()
                .InclusiveBetween(1, 6);

            RuleFor(s => s.Content)
                .NotEmpty()
                .MinimumLength(50)
                .MaximumLength(200)
                .Must(ValidatorExtension.NotContainOnlyNumbers).WithMessage("Content can not be only numbers..");

            RuleFor(s => s.HotelDeals)
                .NotEmpty();

            RuleFor(s => s.Duration)
                .NotEmpty()
                .InclusiveBetween(1, 30);
        }
    }
}
