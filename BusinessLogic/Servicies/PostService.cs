using BusinessEntities.Entities;
using BusinessLogic.Base;
using DataAcces.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Servicies
{
    public class PostService : BaseService
    {
        public PostService(UnitOfWork unitOfWork) 
            :base(unitOfWork)
        {
        }

        public void Add(int id, string text)
        {
            var post = new Post
            {
                Body = text,
                UserId = id,
                NumberOfLikes = 0,
                CreationDate = DateTime.Now
            };

            unitOfWork.Posts.Add(post);

            unitOfWork.Save();
        }
        public List<Post> GetFeed(int id, int page, int pageSize)
        {
            var ids = GetIdList(id);

            var posts = unitOfWork.Posts
                .Query()
                .Include(p => p.User)
                .Include(p => p.Comments)
                    .ThenInclude(c => c.User)
                .Where(p => ids.Contains(p.UserId))
                .OrderByDescending(p => p.CreationDate)
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .ToList();

            return posts;
        }

        public int GetUserIdByPostId(int postId)
        {
            var post = unitOfWork.Posts
                .Query()
                .SingleOrDefault(p => p.Id == postId);

            if (post == null)
                return -1;

            return post.UserId;
        }

        public int GetNumberOfPosts(int id)
        {
            var ids = GetIdList(id);

            return unitOfWork.Posts
                .Query()
                .Where(p => ids.Contains(p.UserId)).Count();
        }

        private List<int> GetIdList(int id)
        {
            var user = unitOfWork.Users
                .Query()
                .Include(u => u.FriendsUser1)
                .Include(u => u.FriendsUser2)
                .SingleOrDefault(u => u.Id == id);

            if (user == null)
                return new List<int>();

            var ids = new List<int> { id };

            foreach (var friendship in user.FriendsUser1)
                ids.Add(friendship.User2Id);

            foreach (var friendship in user.FriendsUser2)
                ids.Add(friendship.User1Id);

            return ids;
        }

        public void RemoveAllFor(int userId)
        {
            var posts = unitOfWork.Posts
                .Query()
                .Where(p => p.UserId == userId).ToList();

            if (posts != null)
            {
                foreach (var post in posts)
                {
                    unitOfWork.Likes.RemoveRange(
                        unitOfWork.Likes
                        .Query()
                        .Where(l => l.PostId == post.Id).ToList());

                    unitOfWork.Save();

                    unitOfWork.Comments.RemoveRange(
                        unitOfWork.Comments
                        .Query()
                        .Where(c => c.PostId == post.Id).ToList());

                    unitOfWork.Save();
                }

                unitOfWork.Posts.RemoveRange(posts);
                unitOfWork.Save();
            }
        }
    }
}
