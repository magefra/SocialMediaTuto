using AutoMapper;
using SocialMedia.Core.src.DTOs;
using SocialMedia.Core.src.Entities;

namespace SocialMedia.Infrastructure.src.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Post, PostDto>().ReverseMap();

            CreateMap<Security, SecurityDto>().ReverseMap();
        }
    }
}
