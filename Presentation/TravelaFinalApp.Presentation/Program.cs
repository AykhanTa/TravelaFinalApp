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
using TravelaFinalApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using TravelaFinalApp.Presentation;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
// Add services to the container.

builder.Services.Register(config);

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
