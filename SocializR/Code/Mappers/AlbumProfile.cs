using AutoMapper;
using BusinessEntities.Entities;
using SocializR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocializR.Code.Mappers
{
    public class AlbumProfile : Profile
    {
        public AlbumProfile()
        {
            CreateMap<Album, ViewAlbumsModel>();
            CreateMap<Photo, EditPhotoModel>();
            CreateMap<Album, EditAlbumModel>();
            CreateMap<Album, AlbumModel>();
            CreateMap<Photo, PhotoProfileModel>();
        }
    }
}
