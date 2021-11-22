using AutoMapper;
using Wasted.API.Dtos;
using Wasted.API.Models;

namespace Wasted.API.Profiles
{
    public class DishProfile : Profile
    {
        public DishProfile()
        {
            CreateMap<Dish, DishReadDto>();
            CreateMap<DishCreateDto, Dish>();
            CreateMap<DishUpdateDto, Dish>();
            CreateMap<Dish, DishUpdateDto>();
        }
    }
}