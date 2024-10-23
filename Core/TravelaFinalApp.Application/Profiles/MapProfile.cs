using AutoMapper;
using Microsoft.AspNetCore.Http;
using TravelaFinalApp.Application.Dtos.AboutDtos;
using TravelaFinalApp.Application.Dtos.BlogDtos;
using TravelaFinalApp.Application.Dtos.CategoryDtos;
using TravelaFinalApp.Application.Dtos.DestinationDtos;
using TravelaFinalApp.Application.Dtos.GuideDtos;
using TravelaFinalApp.Application.Dtos.GuideSocialDtos;
using TravelaFinalApp.Application.Dtos.ServiceDtos;
using TravelaFinalApp.Application.Dtos.SettingDtos;
using TravelaFinalApp.Application.Dtos.SliderDtos;
using TravelaFinalApp.Application.Dtos.SubscribeDtos;
using TravelaFinalApp.Application.Dtos.TestimonialDtos;
using TravelaFinalApp.Application.Dtos.TourDtos;
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

            //testimonial
            CreateMap<TestimonialCreateDto, Testimonial>()
                .ForMember(d => d.Image, map => map.MapFrom(d => d.File.Save(Directory.GetCurrentDirectory(), "images")));

            CreateMap<Testimonial, TestimonialReturnDto>();

            CreateMap<TestimonialUpdateDto,Testimonial>()
                .ForMember(d => d.Image, map => map.MapFrom(d => d.File.Save(Directory.GetCurrentDirectory(), "images")));


            //blog
            CreateMap<Blog, BlogReturnDto>();

            CreateMap<BlogCreateDto,Blog>()
                .ForMember(d => d.Image, map => map.MapFrom(d => d.File.Save(Directory.GetCurrentDirectory(), "images")));

            CreateMap<BlogUpdateDto, Blog>()
                .ForMember(d => d.Image, map => map.MapFrom(d => d.File.Save(Directory.GetCurrentDirectory(), "images")));


            //destination
            CreateMap<Destination,DestinationReturnDto>();

            CreateMap<DestinationCreateDto, Destination>()
                .ForMember(d => d.MainImage, map => map.MapFrom(d => d.File.Save(Directory.GetCurrentDirectory(), "images")));

            CreateMap<DestinationUpdateDto, Destination>()
                .ForMember(d => d.MainImage, map => map.MapFrom(d => d.File.Save(Directory.GetCurrentDirectory(), "images")));

            //guide
            CreateMap<Guide, GuideReturnDto>();

            CreateMap<GuideCreateDto, Guide>()
                .ForMember(d => d.Image, map => map.MapFrom(d => d.File.Save(Directory.GetCurrentDirectory(), "images")));

            CreateMap<GuideSocial,GuideSocialsInGuideReturnDto>();

            CreateMap<GuideUpdateDto, Guide>()
                .ForMember(d => d.Image, map => map.MapFrom(d => d.File.Save(Directory.GetCurrentDirectory(), "images")));

            //guideSocial
            CreateMap<GuideSocialCreateDto, GuideSocial>();
            
            CreateMap<GuideSocial,GuideSocialReturnDto>();

            CreateMap<Guide, GuideInGuideSocialReturnDto>();

            CreateMap<GuideSocialUpdateDto, GuideSocial>();

            //setting
            CreateMap<Setting,SettingReturnDto>();

            CreateMap<SettingCreateDto, Setting>();

            CreateMap<SettingUpdateDto, Setting>();

            //subscribe
            CreateMap<SubscribeCreateDto, Subscribe>();

            CreateMap<Subscribe,SubscribeReturnDto>();

            //category
            CreateMap<CategoryCreateDto,Category>()
                .ForMember(d => d.Image, map => map.MapFrom(d => d.File.Save(Directory.GetCurrentDirectory(), "images")));

            CreateMap<Category,CategoryReturnDto>();

            CreateMap<CategoryUpdateDto, Category>()
                .ForMember(d => d.Image, map => map.MapFrom(d => d.File.Save(Directory.GetCurrentDirectory(), "images")));


            //tour
            CreateMap<Destination,DestinationInTourReturnDto>();

            CreateMap<Tour, TourReturnDto>()
                .ForMember(d => d.Categories, opt => opt.MapFrom(s => s.TourCategories.Select(c => new CategoryReturnDto
                {
                    Id = c.Id,
                    Name = c.Category.Name
                })));

            CreateMap<TourCreateDto,Tour>();

            CreateMap<TourUpdateDto, Tour>();
        }
    } 
}
