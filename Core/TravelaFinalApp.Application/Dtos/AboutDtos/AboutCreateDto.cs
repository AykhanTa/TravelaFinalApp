﻿using FluentValidation;
using Microsoft.AspNetCore.Http;
using TravelaFinalApp.Application.Extensions;

namespace TravelaFinalApp.Application.Dtos.AboutDtos
{
    public class AboutCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile File { get; set; }
    }
    public class AboutCreateDtoValidator : AbstractValidator<AboutCreateDto>
    {
        public AboutCreateDtoValidator()
        {
            RuleFor(a => a.Title)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(100)
                .Must(ValidatorExtension.NotContainOnlyNumbers).WithMessage("Title can not be only numbers..");

            RuleFor(a => a.Description)
                .NotEmpty()
                .MinimumLength(30)
                .MaximumLength(200)
                .Must(ValidatorExtension.NotContainOnlyNumbers).WithMessage("Description can not be only numbers..");

            RuleFor(a => a)
            .Custom((a, context) =>
            {
                if (a.File == null)
                {
                    context.AddFailure("File", "not empty");
                    return;
                }
                if (a.File.Length / 1024 > 500)
                {
                    context.AddFailure("File", "size is too large");
                }
                if (!a.File.ContentType.Contains("image/"))
                {
                    context.AddFailure("File", "file must be only imagee");
                }
            });
        }
    }
}
