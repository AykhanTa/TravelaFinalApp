using AutoMapper;
using Microsoft.AspNetCore.Http;
using TravelaFinalApp.Application.Dtos.AboutDtos;
using TravelaFinalApp.Application.Dtos.ServiceDtos;
using TravelaFinalApp.Application.Dtos.SliderDtos;
using TravelaFinalApp.Application.Extensions;
using TravelaFinalApp.Domain.Entities;

namespace TravelaFinalApp.Application.Profiles
{
    public class MapProfile:Profile
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public MapProfile(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;

            var uriBuilder = new UriBuilder
                (
                _contextAccessor.HttpContext.Request.Scheme,
                _contextAccessor.HttpContext.Request.Host.Host,
               (int)_contextAccessor.HttpContext.Request.Host.Port
                );
            var url = uriBuilder.Uri.AbsoluteUri;

            //slider
            CreateMap<SliderCreateDto, Slider>()
            .ForMember(d => d.Image, map => map.MapFrom(d => d.File.Save(Directory.GetCurrentDirectory(), "images")));

            CreateMap<SliderUpdateDto, Slider>()
                .ForMember(d => d.Image, map => map.MapFrom(d => d.File.Save(Directory.GetCurrentDirectory(), "images")));

            CreateMap<Slider, SliderReturnDto>();

            //about
            CreateMap<AboutCreateDto, About>()
                .ForMember(d => d.Image, map => map.MapFrom(d => d.File.Save(Directory.GetCurrentDirectory(), "images")));

            CreateMap<AboutUpdateDto, About>()
                .ForMember(d => d.Image, map => map.MapFrom(d => d.File.Save(Directory.GetCurrentDirectory(), "images")));

            CreateMap<About, AboutReturnDto>();


            //service
            CreateMap<ServiceCreateDto, Service>();

            CreateMap<Service, ServiceReturnDto>();

            CreateMap<ServiceUpdateDto, Service>();
        }
    } 
}
