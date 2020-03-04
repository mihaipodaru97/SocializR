using BusinessEntities.Entities;
using BusinessLogic.Base;
using DataAcces.Base;
using System;
using System.Linq;

namespace BusinessLogic.Servicies
{
    public class LikeService : BaseService
    {
        public LikeService(UnitOfWork unitOfWork) 
            :base(unitOfWork)
        {
        }

        public bool CanLike(int userId, int postId)
        {
            return unitOfWork.Likes
                .Query()
                .SingleOrDefault(l => l.PostId == postId && l.UserId == userId) == null
                ? true
                : false;
        }

        public void Like(int userId, int postId)
        {
            unitOfWork.Likes.Add(new Like {
                PostId = postId,
                UserId = userId
            });

            unitOfWork.Save();

            var post = unitOfWork.Posts
                .Query()
                .SingleOrDefault(p => p.Id == postId);

            post.NumberOfLikes ++;
            unitOfWork.Posts.Update(post);

            unitOfWork.Save();
        }

        public void Unlike(int userId, int postId)
        {
            unitOfWork.Likes.Remove(new Like
            {
                PostId = postId,
                UserId = userId
            });

            unitOfWork.Save();

            var post = unitOfWork.Posts
                .Query()
                .SingleOrDefault(p => p.Id == postId);

            post.NumberOfLikes --;
            unitOfWork.Posts.Update(post);

            unitOfWork.Save();
        }

        public int GetNumberOfLikes(int postId)
        {
            var post = unitOfWork.Posts
                .Query()
                .SingleOrDefault(p => p.Id == postId);

            return post == null ? 0 : post.NumberOfLikes;
        }

        public void RemoveAllFor(int userId)
        {
            var likes = unitOfWork.Likes
                .Query()
                .Where(l => l.UserId == userId).ToList();

            foreach (var like in likes)
            {
                var post = unitOfWork.Posts
                    .Query()
                    .SingleOrDefault(p => p.Id == like.PostId);

                post.NumberOfLikes--;

                unitOfWork.Posts.Update(post);
                unitOfWork.Save();
            }

            unitOfWork.Likes.RemoveRange(likes);

            unitOfWork.Save();
        }
    }
}
