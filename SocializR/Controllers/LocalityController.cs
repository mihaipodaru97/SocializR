using System.Collections.Generic;
using AutoMapper;
using BusinessLogic.Servicies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SocializR.Code;
using SocializR.Models;
using SocializR.Code.Security;

namespace SocializR.Controllers
{
    public class LocalityController : BaseController
    {
        private readonly LocalityService localityService;
        private readonly CurrentUser currentUser;

        public LocalityController(CurrentUser currentUser, LocalityService service, IMapper mapper)
            :base(mapper)
        {
            this.currentUser = currentUser;
            this.localityService = service;
        }

        [HttpGet]
        public IActionResult GetLocalities(int countyId)
        {
            var localities = localityService.GetById(countyId);
            var result = new List<SelectListItem>();
            localities.ForEach(l => result.Add(mapper.Map<SelectListItem>(l)));

            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = Constants.Admin)]
        public IActionResult AddLocality(string locality, int countyId)
        {
            if (!currentUser.CanCreateCities)
                return AccessDenied();

            if (localityService.Add(locality, countyId))
                return Ok();

            return NotFound();
        }
    }
}