using AutoMapper;
using SWFU.CMS.Core.Entities;
using SWFU.CMS.Insfrastructure.Resources;

namespace SWFU.CMS.API.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Post, PostResource>()
                .ForMember(dest => dest.UpdateTime, opt => opt.MapFrom(src => src.LastModified));
            CreateMap<PostResource, Post>();
        }
    }
}