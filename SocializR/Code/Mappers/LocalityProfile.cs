using AutoMapper;
using BusinessEntities.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocializR.Code.Mappers
{
    public class LocalityProfile : Profile
    {
        public LocalityProfile()
        {
            CreateMap<Locality, SelectListItem>()
                .ForMember(sl => sl.Text, a => a.MapFrom(l => l.Name))
                .ForMember(sl => sl.Value, a => a.MapFrom(l => l.Id.ToString()));
        }
    }
}
