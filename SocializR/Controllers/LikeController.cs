using BusinessLogic.Servicies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocializR.Code;
using SocializR.Models;
using SocializR.Code.Security;

namespace SocializR.Controllers
{
    public class LikeController : BaseController
    {
        private readonly LikeService likeService;
        private readonly CurrentUser currentUser;
        private readonly FriendService friendService;
        private readonly PostService postService;
        public LikeController(LikeService likeService, CurrentUser currentUser, 
            FriendService friendService, PostService postService)
        {
            this.friendService = friendService;
            this.currentUser = currentUser;
            this.likeService = likeService;
            this.postService = postService;
        }
        
        [HttpPost]
        [Authorize(Roles = Constants.Member)]
        public int Like(int postId)
        {
            var userId = postService.GetUserIdByPostId(postId);

            if (!friendService.AreFriends(userId, currentUser.Id) &&
                !(currentUser.Id == userId))
                return likeService.GetNumberOfLikes(postId);

            if (likeService.CanLike(currentUser.Id, postId) == false)
                return likeService.GetNumberOfLikes(postId);

            likeService.Like(currentUser.Id, postId);

            return likeService.GetNumberOfLikes(postId);
        }

        [HttpPost]
        [Authorize(Roles = Constants.Member)]
        public int Unlike(int postId)
        {
            var userId = postService.GetUserIdByPostId(postId);

            if (!friendService.AreFriends(userId, currentUser.Id) &&
                !(currentUser.Id == userId))
                return likeService.GetNumberOfLikes(postId);

            if (likeService.CanLike(currentUser.Id, postId) == true)
                return likeService.GetNumberOfLikes(postId);

            likeService.Unlike(currentUser.Id, postId);

            return likeService.GetNumberOfLikes(postId);
        }
    }
}