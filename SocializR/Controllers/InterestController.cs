using System.Collections.Generic;
using AutoMapper;
using BusinessLogic.Servicies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SocializR.Code;
using SocializR.Code.Settings;
using SocializR.Code.Security;

namespace SocializR.Controllers
{
    public class InterestController : BaseController
    {
        private readonly InterestService interestService;

        public InterestController(InterestService interestService, AppSettings settings, IMapper mapper)
            :base(settings, mapper)
        {
            this.interestService = interestService;
        }

        [HttpGet]
        public IActionResult GetAllInterests(string interestName)
        {
            var interests = interestService.Get(interestName, settings.numberOfInterests);
            var results = new List<SelectListItem>();
            interests.ForEach(i => results.Add(mapper.Map<SelectListItem>(i)));

            return Json(results);
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            return Json(interestService.Get(id).Name);
        }

        [HttpPost]
        [Authorize(Roles = Constants.Admin)]
        public IActionResult AddInterest(string interest)
        {
            if(interestService.Add(interest))
                return Ok();

            return NotFound();
        }
    }
}