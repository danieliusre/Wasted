using AutoMapper;
using Wasted.API.Dtos;
using Wasted.API.Models;

namespace Wasted.API.Profiles
{
    public class TipProfile : Profile
    {
        public TipProfile()
        {
            CreateMap<Tip, TipReadDto>();
            CreateMap<TipCreateDto, Tip>();
            CreateMap<TipUpdateDto, Tip>();
            CreateMap<Tip, TipUpdateDto>();
        }
    }
}