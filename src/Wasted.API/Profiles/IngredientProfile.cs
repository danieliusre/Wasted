using AutoMapper;
using Wasted.API.Dtos;
using Wasted.API.Models;

namespace Wasted.API.Profiles
{
    public class IngredientProfile : Profile
    {
        public IngredientProfile()
        {
            CreateMap<Ingredient, IngredientReadDto>();
            CreateMap<IngredientCreateDto, Ingredient>();
            CreateMap<IngredientUpdateDto, Ingredient>();
            CreateMap<Ingredient, IngredientUpdateDto>();
        }
    }
}