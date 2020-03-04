using BusinessLogic.Servicies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocializR.Code.Security;

namespace SocializR.Controllers
{
    public class PostController : Controller
    {
        private readonly PostService postService;
        public PostController(PostService postService)
        {
            this.postService = postService;
        }

        [HttpPost]
        [Authorize(Roles = Constants.Member)]
        public void AddPost(int id, string text)
        {
            postService.Add(id, text);
        }
    }
}