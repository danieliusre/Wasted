using AutoMapper;
using Wasted.API.Dtos;
using Wasted.API.Models;

namespace Wasted.API.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductReadDto>();
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<Product, UserUpdateDto>();
        }
    }
}