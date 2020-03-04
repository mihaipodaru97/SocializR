using BusinessEntities.Entities;
using BusinessLogic.Base;
using DataAcces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Servicies
{
    public class PhotoService : BaseService
    {
        public PhotoService(UnitOfWork unitOfWork) 
            :base(unitOfWork)
        {
        }

        public byte[] GetPhoto(int id)
        {
            return unitOfWork.Photos
                .Query()
                .Where(p => p.Id == id)
                .Select(p => p.Image)
                .FirstOrDefault();
        }

        public void Add(Photo photo)
        {
            unitOfWork.Photos.Add(photo);

            unitOfWork.Save();
        }

        public void ChangePhotoDescription(int photoId, int albumId, string description)
        {
            var photo = unitOfWork.Photos
                .Query()
                .SingleOrDefault(p => p.Id == photoId);

            photo.Description = description;
            unitOfWork.Photos.Update(photo);

            unitOfWork.Save();
        }

        public void Delete(int photoId)
        {
            unitOfWork.Photos.Remove(new Photo {
                Id = photoId
            });

            unitOfWork.Save();
        }
    }
}