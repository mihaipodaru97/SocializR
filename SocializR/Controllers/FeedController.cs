using System.Collections.Generic;
using AutoMapper;
using BusinessLogic.Servicies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocializR.Code;
using SocializR.Code.Settings;
using SocializR.Models;
using SocializR.Code.Security;

namespace SocializR.Controllers
{
    [Authorize]
    public class FeedController : BaseController
    {
        private readonly UserService userService;
        private readonly PostService postService;
        private readonly CurrentUser currentUser;
        private readonly LikeService likeService;
        public FeedController(UserService userService, PostService postService,
            CurrentUser currentUser, LikeService likeService, IMapper mapper, AppSettings settings)
            :base(settings, mapper)
        {
            this.likeService = likeService;
            this.currentUser = currentUser;
            this.postService = postService;
            this.userService = userService;
        }

        [HttpGet]
        [ResponseCache(Duration = 10)]
        [Authorize(Roles = Constants.Member)]
        public IActionResult Index(int page = 1)
        {
            var posts = postService.GetFeed(currentUser.Id, page, settings.PageSize);
            var numberOfPosts = postService.GetNumberOfPosts(currentUser.Id);
            var model = new List<PostFeedModel>();
            
            posts.ForEach(p => {
                var post = mapper.Map<PostFeedModel>(p);
                post.CanLike = likeService.CanLike(currentUser.Id, post.Id);
                model.Add(post);
            });

            var pagedModel = PaginatedList<PostFeedModel>.Create(model, numberOfPosts, page, settings.PageSize);

            return View(pagedModel);
        }
    }
}