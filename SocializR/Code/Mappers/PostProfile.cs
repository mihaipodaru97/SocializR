using AutoMapper;
using BusinessEntities.Entities;
using BusinessLogic.Servicies;
using SocializR.Models;

namespace SocializR.Code.Mappers
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostFeedModel>();
        }
    }
}
