using System;
using System.Collections.Generic;
using System.Linq;
using BusinessEntities.Entities;
using BusinessLogic.Base;
using DataAcces.Base;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Servicies
{
    public class AlbumService : BaseService
    {
        private readonly FriendService friendService;
        public AlbumService(UnitOfWork unitOfWork, FriendService friendService) 
            :base(unitOfWork)
        {
            this.friendService = friendService;
        }

        public void AddAlbum(Album album)
        {
            unitOfWork.Albums.Add(album);

            unitOfWork.Save();
        }

        public List<Album> GetAlbumsById(int userId)
        {
            var user = unitOfWork.Users.
                Query()
                .Include(u => u.Albums)
                .SingleOrDefault(u => u.Id == userId);

            if (user == null)
                return null;

            return user.Albums.ToList();
        }

        public Album GetAlbumById(int id)
        {
            return unitOfWork.Albums
                .Query()
                .Include(a => a.Photos)
                .SingleOrDefault(a => a.Id == id);
        }

        public void EditAlbumName(int userId, int albumId, string name)
        {
            var album = unitOfWork.Albums
                .Query()
                .SingleOrDefault(a => a.Id == albumId);

            if (album != null && album.UserId == userId)
            {
                unitOfWork.Albums.Update(new Album
                {
                    Id = albumId,
                    Name = name,
                    UserId = userId
                });

                unitOfWork.Save();
            }
        }

        public User GetUser(int id)
        {
            var album = unitOfWork.Albums
                .Query()
                .Include(a => a.User)
                    .ThenInclude(u => u.FriendsUser1)
                .Include(a => a.User)
                    .ThenInclude(u => u.FriendsUser2)
                .SingleOrDefault(a => a.Id == id);

            if (album == null)
                return null;

            return album.User;
        }

        public int GetUserId(int id)
        {
            return unitOfWork.Albums
                .Query()
                .SingleOrDefault(a => a.Id == id).UserId;
        }

        public List<Photo> GetPhotos(int id)
        {
            var album = unitOfWork.Albums
                .Query()
                .Include(a => a.Photos)
                .SingleOrDefault(a => a.Id == id);

            if (album == null)
                return null;

            return album.Photos.ToList();
        }

        public bool CanSee(int id, User user)
        {
            return friendService.AreFriends(user, id)
                || user.Privacy == false
                || user.Id == id;
        }

        public string GetAlbumName(int id)
        {
            var album =  unitOfWork.Albums
                .Query()
                .SingleOrDefault(a => a.Id == id);

            if (album == null)
                return "";

            return album.Name;
        }

        public void RemoveAllFor(int userId)
        {
            var albums = unitOfWork.Albums
                .Query()
                .Include(a => a.Photos)
                .Where(a => a.UserId == userId).ToList();

            if (albums != null)
            {
                foreach (var album in albums)
                {
                    unitOfWork.Photos.RemoveRange(album.Photos);
                    unitOfWork.Save();
                }

                unitOfWork.Albums.RemoveRange(albums);
                unitOfWork.Save();
            }
        }
    }
}
