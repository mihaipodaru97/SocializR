using BusinessEntities.Entities;
using BusinessLogic.Servicies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocializR.Code;
using SocializR.Models;
using SocializR.Code.Security;

namespace SocializR.Controllers
{
    public class CommentController : BaseController
    {
        private readonly CommentService commentService;
        private readonly CurrentUser currentUser;
        private readonly FriendService friendService;
        private readonly PostService postService;

        public CommentController(CommentService commentService, CurrentUser currentUser,
            FriendService friendService, PostService postService)
        {
            this.postService = postService;
            this.currentUser = currentUser;
            this.commentService = commentService;
            this.friendService = friendService;
        }

        [HttpPost]
        [Authorize(Roles = Constants.Member)]
        public IActionResult AddComment(Comment comment)
        {
            var userId = postService.GetUserIdByPostId(comment.PostId);

            if (!friendService.AreFriends(userId, currentUser.Id) &&
                !(currentUser.Id == userId))
                return AccessDenied();

            comment.UserId = currentUser.Id;
            commentService.AddComment(comment);

            return Ok();
        }
    }
}