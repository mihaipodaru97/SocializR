using System;
using System.Collections.Generic;
using System.Linq;
using BusinessEntities.Entities;
using BusinessEntities.Types;
using BusinessLogic.Base;
using DataAcces.Base;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Servicies
{
    public class UserService : BaseService
    {
        private readonly FriendService friendService;
        private readonly PostService postService;
        private readonly LikeService likeService;
        private readonly AlbumService albumService;
        private readonly CommentService commentService;
        private readonly InterestService interestService;
        public UserService(UnitOfWork unitOfWork, FriendService friendService, PostService postService,
            LikeService likeService, AlbumService albumService, CommentService commentService,
            InterestService interestService) 
            : base(unitOfWork)
        {
            this.interestService = interestService;
            this.commentService = commentService;
            this.albumService = albumService;
            this.likeService = likeService;
            this.postService = postService;
            this.friendService = friendService;
        }

        public User Login(string email, string password)
        {
            return unitOfWork.Users
                .Query()
                .Where(u => u.Email == email && u.Password == password)
                .Include(u => u.UserRole)
                    .ThenInclude(ur => ur.Role)
                .FirstOrDefault();
        }

        public List<User> Get(string userName, int numberOfResults)
        {
            if (userName == null)
                return new List<User>();

            userName = userName.Trim();

            var list = unitOfWork.Users
                .Query()
                .Where(u => u.FirstName.Contains(userName) || u.LastName.Contains(userName))
                .OrderBy(u => u.FirstName)
                .ThenBy(u => u.LastName)
                .Take(numberOfResults);

            if (list == null)
                return new List<User>();

            return list.ToList();
        }

        public User Get(int id)
        {
            return unitOfWork.Users
                .Query()
                .Include(u => u.Albums)
                .Include(u => u.FriendsUser1)
                .Include(u => u.FriendsUser2)
                .Include(u => u.UserInterest)
                    .ThenInclude(ur => ur.Interest)
                .SingleOrDefault(u => u.Id == id);
        }

        public byte[] GetProfilePhoto(int id)
        {
            return unitOfWork.Users
                .Query()
                .Where(u => u.Id == id)
                .Select(u => u.ProfilePhoto)
                .FirstOrDefault();
        }

        public User GetByEmail(string email)
        {
            return unitOfWork.Users
                .Query()
                .Include(u => u.UserInterest)
                    .ThenInclude(ur => ur.Interest)
                .SingleOrDefault(u => u.Email == email);
        }

        public bool Add(User user)
        {
            user.CreationDate = DateTime.Now;

            unitOfWork.Users.Add(user);

            if (!unitOfWork.Save())
                return false;

            var id = unitOfWork.Users
                .Query()
                .SingleOrDefault(u => u.Email == user.Email).Id;

            unitOfWork.UserRole.Add(new UserRole
            {
                UserId = id,
                RoleId = (int)RoleType.Member
            });

            return unitOfWork.Save();
        }

        public bool Remove(int userId)
        {
            commentService.RemoveAllFor(userId);
            albumService.RemoveAllFor(userId);
            postService.RemoveAllFor(userId);
            friendService.RemoveAllFor(userId);
            likeService.RemoveAllFor(userId);
            interestService.RemoveAllFor(userId);

            unitOfWork.UserRole.RemoveRange(
                unitOfWork.UserRole
                .Query()
                .Where(ur => ur.UserId == userId).ToList());

            unitOfWork.Users.Remove(
                unitOfWork.Users
                .Query()
                .SingleOrDefault(u => u.Id == userId));

            return unitOfWork.Save();
        }

        public User GetById(int id)
        {
            return unitOfWork.Users
                .Query()
                .Include(u => u.UserInterest)
                .SingleOrDefault(u => u.Id == id);
        }

        public bool CanAdd(User user)
        {
            return unitOfWork.Users
                .Query()
                .Any(u => u.Email == user.Email);
        }

        public bool Edit(User updatedUser, User existingUser)
        {
            var existingInterests = existingUser.UserInterest;
            var newInterests = updatedUser.UserInterest;
            
            updatedUser.Email = existingUser.Email;
            updatedUser.Password = existingUser.Password;
            updatedUser.Id = existingUser.Id;
            updatedUser.ProfilePhoto = (updatedUser.ProfilePhoto != null && updatedUser.ProfilePhoto.Any()) 
                ? updatedUser.ProfilePhoto 
                : existingUser.ProfilePhoto;
            updatedUser.UserInterest = null;

            unitOfWork.Users.Update(updatedUser);
            var userUpdateResult = unitOfWork.Save();

            unitOfWork.UserInterests.RemoveRange(existingInterests);
            var interestRemoveResult = unitOfWork.Save();

            unitOfWork.UserInterests.AddRange(newInterests);
            var interestAddResult = unitOfWork.Save();

            return userUpdateResult && interestRemoveResult && interestAddResult;
        }
    }
}
