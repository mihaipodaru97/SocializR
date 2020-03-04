using AutoMapper;
using BusinessEntities.Entities;
using BusinessLogic.Servicies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SocializR.Code;
using SocializR.Code.Settings;
using SocializR.Models;
using System.Linq;
using SocializR.Code.Security;

namespace SocializR.Controllers
{
    public class ProfileController : BaseController
    {
        private readonly UserService userService;
        private readonly CountyService countyService;
        private readonly CurrentUser currentUser;
        private readonly FriendService friendService;
        public ProfileController(UserService userService, FriendService friendService, CountyService countyService, 
            CurrentUser currentUser, AppSettings settings, IMapper mapper)
            : base(settings, mapper)
        {
            this.friendService = friendService;
            this.countyService = countyService;
            this.userService = userService;
            this.currentUser = currentUser;
        }


        [ResponseCache(Duration = 60)]
        [HttpGet]
        public IActionResult ProfilePhoto(int id)
        {
            var photo = userService.GetProfilePhoto(id);
            if (photo != null)
                return File(photo, "image/jpeg");

            return NotFound();
        }

        [HttpGet]
        public IActionResult ViewProfile(int id)
        {
            var user = userService.Get(id);
            if (user == null)
                return NotFoundView();

            var model = mapper.Map<UserModel>(user);

            if (currentUser.IsAuthenticated)
            {
                model.FriendRequestSent = friendService.FriendRequestSent(currentUser.Id, model.Id);
                model.Friends = friendService.AreFriends(user, currentUser.Id);
            }

            model.CanSeeProfile = user.Privacy == false || model.Friends
                || model.Id == currentUser.Id || currentUser.CanViewProfile;

            return View(model);
        }

        [Authorize(Roles = Constants.Member)]
        [HttpGet]
        public IActionResult EditProfile(int id)
        {
            var user = userService.GetById(id);
            if (user == null)
                return NotFoundView();

            if (user.Id != currentUser.Id && !currentUser.CanEditProfile)
                return AccessDenied();

            var model = mapper.Map<EditProfileModel>(user);
            model.Counties = countyService.GetAll().Select(a => mapper.Map<SelectListItem>(a)).ToList();

            return View(model);
        }

        [Authorize(Roles = Constants.Member)]
        [HttpPost]
        public IActionResult EditProfile(EditProfileModel model)
        {
            var existingUser = userService.GetById(model.Id);
            if (existingUser == null)
                return NotFoundView();

            if (model.Id != currentUser.Id && !currentUser.CanEditProfile)
                return AccessDenied();

            if (!ModelState.IsValid)
            {
                model.Counties = countyService.GetAll().Select(a => mapper.Map<SelectListItem>(a)).ToList();

                return View(model);
            }

            var updatedUser = mapper.Map<User>(model);
            if (!userService.Edit(updatedUser, existingUser))
                return InternalServerErrorView();

            return RedirectToAction("ViewProfile", "Profile", new { id = model.Id });
        }
    }
}
