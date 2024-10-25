using Microsoft.Extensions.DependencyInjection;
using TravelaFinalApp.Persistence.Repositories.Interfaces;
using TravelaFinalApp.Persistence.Repositories;

namespace TravelaFinalApp.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositoryLayer(this IServiceCollection services)
        {
            services.AddScoped<ISliderRepository, SliderRepository>();
            services.AddScoped<IAboutRepository, AboutRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<ITestimonialRepository, TestimonialRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IDestinationRepository, DestinationRepository>();
            services.AddScoped<IGuideRepository, GuideRepository>();
            services.AddScoped<IGuideSocialRepository, GuideSocialRepository>();
            services.AddScoped<ISettingRepository, SettingRepository>();
            services.AddScoped<ISubscribeRepository, SubscribeRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IGetAppointmentRepository, GetAppointmentRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITourRepository, TourRepository>();
            services.AddScoped<IPackageRepository, PackageRepository>();
            services.AddScoped<IPackageImageRepository, PackageImageRepository>();
            services.AddScoped<ITourCategoryRepository, TourCategoryRepository>();
            services.AddScoped<ITourImageRepository, TourImageRepository>();



            return services;
        }
    }
}
