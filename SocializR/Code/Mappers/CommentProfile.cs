using AutoMapper;
using BusinessEntities.Entities;
using SocializR.Models;

namespace SocializR.Code.Mappers
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentFeedModel>();
        }
    }
}
