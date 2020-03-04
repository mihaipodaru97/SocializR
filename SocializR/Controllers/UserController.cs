using AutoMapper;
using BusinessLogic.Servicies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SocializR.Code;
using SocializR.Code.Settings;
using System.Collections.Generic;

namespace SocializR.Controllers
{
    public class UserController : BaseController
    {
        private readonly UserService service;

        public UserController(UserService service, AppSettings settings, IMapper mapper)
            : base(settings, mapper)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult SearchUsers(string userName)
        {
            var users = service.Get(userName, settings.PageSize);
            var results = new List<SelectListItem>();

            users.ForEach(u => results.Add(mapper.Map<SelectListItem>(u)));

            return Json(results);
        }
    }
}
