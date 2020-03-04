using AutoMapper;
using BusinessEntities.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocializR.Code.Mappers
{
    public class CountyProfile : Profile
    {
        public CountyProfile()
        {
            CreateMap<County, SelectListItem>()
                .ForMember(s => s.Text, a => a.MapFrom(c => c.Name))
                .ForMember(s => s.Value, a => a.MapFrom(c => c.Id.ToString()));
        }
    }
}
