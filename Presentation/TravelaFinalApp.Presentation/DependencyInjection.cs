using FluentValidation.AspNetCore;
using FluentValidation;
using TravelaFinalApp.Application.Dtos.AboutDtos;
using TravelaFinalApp.Application.Dtos.BlogDtos;
using TravelaFinalApp.Application.Dtos.CategoryDtos;
using TravelaFinalApp.Application.Dtos.SliderDtos;
using TravelaFinalApp.Application.Dtos.UserDtos;
using TravelaFinalApp.Application.Interfaces;
using TravelaFinalApp.Persistence.Implementations;

namespace TravelaFinalApp.Presentation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddScoped<ISliderService, SliderService>();
            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<ITestimonialService, TestimonialService>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<IDestinationService, DestinationService>();
            services.AddScoped<IGuideService, GuideService>();
            services.AddScoped<IGuideSocialService, GuideSocialService>();
            services.AddScoped<ISettingService, SettingService>();
            services.AddScoped<ISubscribeService, SubscribeService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ITourService, TourService>();
            services.AddScoped<IPackageService, PackageService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
