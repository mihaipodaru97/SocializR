using AutoMapper;
using BusinessEntities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using SocializR.Code.ExtensionMethods;
using SocializR.Models;
using System.Linq;

namespace SocializR.Code.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterModel, User>()
                .ForMember(u => u.Id, s => s.MapFrom(r => 0))
                .ForMember(u => u.Gender, s => s.MapFrom(r => r.Gender.Equals("Female") ? false : true))
                .ForMember(u => u.Privacy, s => s.MapFrom(r => r.Privacy.Equals("Public") ? false : true));

            CreateMap<User, EditProfileModel>()
                .ForMember(ep => ep.Interests, s => s.MapFrom(u => u.UserInterest.Select(ur => ur.Interest.Id).ToList()))
                .ForMember(u => u.ProfilePhoto, s => s.Ignore())
                .ForMember(u => u.Gender, s => s.MapFrom(r => r.Gender ? "Male" : "Female"))
                .ForMember(u => u.Privacy, s => s.MapFrom(r => r.Privacy ? "Private" : "Public"));

            CreateMap<EditProfileModel, User>()
                .ForMember(u => u.UserInterest, s => s.MapFrom(ep => ep.Interests.Select(interestId => new UserInterest
                {
                    InterestId = interestId,
                    UserId = ep.Id
                }).ToList()))
                .ForMember(u => u.ProfilePhoto, s => s.MapFrom(r => r.ProfilePhoto.GetFileBytes()))
                .ForMember(u => u.Gender, s => s.MapFrom(r => r.Gender.Equals("Female") ? false : true))
                .ForMember(u => u.Privacy, s => s.MapFrom(r => r.Privacy.Equals("Public") ? false : true));

            CreateMap<User, UserModel>()
                .ForMember(ur => ur.InterestsNames, s => s.MapFrom(u => u.UserInterest.Select(ur => ur.Interest.Name).ToList()));

            CreateMap<User, FriendModel>();

            CreateMap<User, UserFeedModel>();

            CreateMap<User, SelectListItem>()
                .ForMember(sl => sl.Text, a => a.MapFrom(u => $"{u.FirstName} {u.LastName}"))
                .ForMember(sl => sl.Value, a => a.MapFrom(l => l.Id.ToString()));

        }
    }
}
