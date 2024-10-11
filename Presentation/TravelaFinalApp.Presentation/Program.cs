using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TravelaFinalApp.Application.Interfaces;
using TravelaFinalApp.Application.Profiles;
using TravelaFinalApp.Persistence.Data;
using TravelaFinalApp.Persistence.Implementations;
using TravelaFinalApp.Application.Dtos.SliderDtos;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using TravelaFinalApp.Persistence.Repositories.Interfaces;
using TravelaFinalApp.Persistence.Repositories;
using TravelaFinalApp.Presentation.Middlewares;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TravelaDbContext>(opt =>
{
    opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
});

//services
builder.Services.AddScoped<ISliderService,SliderService>();
builder.Services.AddScoped<IAboutService,AboutService>();
builder.Services.AddScoped<IServiceService,ServiceService>();
builder.Services.AddScoped<ITestimonialService,TestimonialService>();
builder.Services.AddScoped<IBlogService,BlogService>();
builder.Services.AddScoped<IDestinationService,DestinationService>();
builder.Services.AddScoped<IGuideService,GuideService>();
builder.Services.AddScoped<IGuideSocialService,GuideSocialService>();
builder.Services.AddScoped<ISettingService,SettingService>();
builder.Services.AddScoped<ISubscribeService,SubscribeService>();


builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

builder.Services.AddValidatorsFromAssemblyContaining<SliderCreateDtoValidator>();

builder.Services.AddFluentValidationRulesToSwagger();


builder.Services.AddHttpContextAccessor();

//repos
builder.Services.AddScoped<ISliderRepository,SliderRepository>();
builder.Services.AddScoped<IAboutRepository,AboutRepository>();
builder.Services.AddScoped<IServiceRepository,ServiceRepository>();
builder.Services.AddScoped<ITestimonialRepository,TestimonialRepository>();
builder.Services.AddScoped<IBlogRepository,BlogRepository>();
builder.Services.AddScoped<IDestinationRepository,DestinationRepository>();
builder.Services.AddScoped<IGuideRepository,GuideRepository>();
builder.Services.AddScoped<IGuideSocialRepository,GuideSocialRepository>();
builder.Services.AddScoped<ISettingRepository,SettingRepository>();
builder.Services.AddScoped<ISubscribeRepository,SubscribeRepository>();

builder.Services.AddAutoMapper(opt =>
{
    opt.AddProfile(new MapProfile(new HttpContextAccessor()));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
