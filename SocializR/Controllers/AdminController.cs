using AutoMapper;
using BusinessLogic.Servicies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SocializR.Code;
using SocializR.Models;
using System.Collections.Generic;
using System.Linq;
using SocializR.Code.Security;
using System.Xml.Linq;

namespace SocializR.Controllers
{
    [Authorize(Roles = Constants.Admin)]
    public class AdminController : BaseController
    {
        private readonly CurrentUser currentUser;
        private readonly CountyService countyService;

        public AdminController(CurrentUser currentUser, CountyService countyService, IMapper mapper)
            : base(mapper)
        {
            this.countyService = countyService;
            this.currentUser = currentUser;
        }

        [HttpGet]
        [Authorize(Roles = Constants.Admin)]
        public IActionResult Panel()
        {
            var model = countyService.GetAll().Select(a => mapper.Map<SelectListItem>(a)).ToList();

            return View(model);
        }
    }
}