using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using BusinessEntities.Entities;
using BusinessLogic.Servicies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SocializR.Code;
using SocializR.Code.Settings;
using SocializR.Models;
using SocializR.Code.Security;

namespace SocializR.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UserService userService;
        private readonly CountyService countyService;
        private readonly CurrentUser currentUser;

        public AccountController(UserService userService, CountyService countyService,
            CurrentUser currentUser, AppSettings settings, IMapper mapper)
            : base(settings, mapper)
        {
            this.currentUser = currentUser;
            this.userService = userService;
            this.countyService = countyService;
        }

        [HttpGet]
        [Authorize(Roles = Constants.Admin)]
        public IActionResult GetPermission()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (currentUser.IsAuthenticated)
                return RedirectToAction("Index", "Feed");

            var model = new LoginModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (currentUser.IsAuthenticated)
                return RedirectToAction("Index", "Feed");

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = userService.Login(model.Email, model.Password);
            if (user == null)
            {
                model.IsInvalid = true;

                return View(model);
            }

            LogIn(user);

            return RedirectToAction("Index", "Feed");
        }

        [HttpPost]
        [Authorize]
        public IActionResult Delete(int id)
        {
            if (!currentUser.CanDeleteUser || id == currentUser.Id)
                return InternalServerErrorView();

            userService.Remove(id);

            return Ok();
        }

        [Authorize(Roles = Constants.Member)]
        public IActionResult Logout()
        {
            LogOut();

            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (currentUser.IsAuthenticated)
                return RedirectToAction("Index", "Feed");

            var model = new RegisterModel
            {
                Counties = countyService.GetAll().Select(a => mapper.Map<SelectListItem>(a)).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (currentUser.IsAuthenticated)
                return RedirectToAction("Index", "Feed");

            if (!ModelState.IsValid)
            {
                model.Counties = countyService.GetAll().Select(a => mapper.Map<SelectListItem>(a)).ToList();

                return View(model);
            }

            var user = mapper.Map<User>(model);
            if (userService.CanAdd(user))
            {
                ModelState.AddModelError(nameof(user.Email), "Email-ul exista deja");
                model.Counties = countyService.GetAll().Select(a => mapper.Map<SelectListItem>(a)).ToList();

                return View(model);
            }

            if (!userService.Add(user))
                return InternalServerErrorView();

            return RedirectToAction("Login", "Account");
        }

        private void LogIn(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            user.UserRole.ToList().ForEach(ur => claims.Add(new Claim(ClaimTypes.Role, ur.Role.Name)));

            var identity = new ClaimsIdentity(claims, Code.Security.Constants.AuthentificationScheme);
            var principal = new ClaimsPrincipal(identity);

            HttpContext.SignInAsync(
                scheme: Code.Security.Constants.AuthentificationScheme,
                principal: principal
                );
        }

        private void LogOut()
        {
            HttpContext.SignOutAsync(scheme: Constants.AuthentificationScheme);
        }
    }
}