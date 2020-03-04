using AutoMapper;
using BusinessEntities.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocializR.Code.Mappers
{
    public class InterestProfile : Profile
    {
        public InterestProfile()
        {
            CreateMap<Interest, SelectListItem>()
                .ForMember(sl => sl.Text, a => a.MapFrom(i => i.Name))
                .ForMember(sl => sl.Value, a => a.MapFrom(i => i.Id.ToString()));
        }
    }
}
