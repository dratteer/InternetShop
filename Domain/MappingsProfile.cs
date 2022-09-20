using AutoMapper;
using Core.Entities;
using Domain.DTOs;

namespace Domain
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            InitMap();
        }

        private void InitMap()
        {
            CreateMap<Brand, BrandDTO>()
                .ForAllMembers(d => d.Condition((srt, dest, srtmember) => srtmember != null));

            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(c => c.BrandValue))
                .ForAllMembers(d => d.Condition((srt, dest, srtmember) => srtmember != null));
        }
    }
}
