using AutoMapper;
using RentACarAPI.API.Models.BrandVM;
using RentACarAPI.API.Models.CarVM;
using RentACarAPI.API.Models.ColorVM;
using RentACarAPI.Entity.Concrete;
using RentACarAPI.Entity.DTOs;

namespace RentACarAPI.API.Models.AutoMapper
{
    public class AutoMapperProfiler:Profile
    {
        public AutoMapperProfiler()
        {
            CreateMap<Car,CreateCarVM>().ReverseMap();
            CreateMap<Car,UpdateCarVM>().ReverseMap();
            CreateMap<Car,DeleteCarVM>().ReverseMap();           
            CreateMap<Car,CarDetailsDto>().ReverseMap();
           

            CreateMap<Brand,BrandViewModel>().ReverseMap();

            CreateMap<Color,ColorViewModel>().ReverseMap();
        }
    }
}
