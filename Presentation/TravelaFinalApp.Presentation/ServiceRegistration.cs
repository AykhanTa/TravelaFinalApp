using FluentValidation;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TravelaFinalApp.Application.Dtos.SliderDtos;
using TravelaFinalApp.Application.Interfaces;
using TravelaFinalApp.Application.Profiles;
using TravelaFinalApp.Domain.Entities;
using TravelaFinalApp.Persistence.Data;
using TravelaFinalApp.Persistence.Implementations;
using TravelaFinalApp.Persistence.Repositories;
using TravelaFinalApp.Persistence.Repositories.Interfaces;

namespace TravelaFinalApp.Presentation
{
    public static class ServiceRegistration
    {
        public static void Register(this IServiceCollection services, IConfiguration config)
        {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<TravelaDbContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            services.AddHttpContextAccessor();

            //services
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
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IEmailService, EmailService>();

            services.AddScoped<IAuthService, AuthService>();


            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();

            services.AddValidatorsFromAssemblyContaining<SliderCreateDtoValidator>();

            services.AddFluentValidationRulesToSwagger();

            services.AddHttpContextAccessor();


            //repos
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
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITourRepository, TourRepository>();
            services.AddScoped<ITourCategoryRepository, TourCategoryRepository>();
            services.AddScoped<ITourImageRepository, TourImageRepository>();

            services.AddAutoMapper(opt =>
            {
                opt.AddProfile(new MapProfile(new HttpContextAccessor()));
            });

            services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = true;
                opt.Password.RequiredLength = 6;
                opt.Password.RequireUppercase = true;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireDigit = true;

                opt.SignIn.RequireConfirmedEmail = true;

            }).AddEntityFrameworkStores<TravelaDbContext>().AddDefaultTokenProviders();

            services.AddAuthentication(cfg =>
            {
                cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                cfg.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = config["Jwt:Issuer"],
                    ValidAudience = config["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:SecretKey"])),
                    ClockSkew=TimeSpan.Zero
                };
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "JWTToken_Auth_API",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
            });
        }
    }
}
