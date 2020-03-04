using BusinessLogic.Servicies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocializR.Code;
using SocializR.Models;
using SocializR.Code.Security;

namespace SocializR.Controllers
{
    public class CountyController : BaseController
    {
        private readonly CountyService countyService;
        private readonly CurrentUser currentUser;

        public CountyController(CurrentUser currentUser, CountyService countyService)
        {
            this.currentUser = currentUser;
            this.countyService = countyService;
        }

        [HttpPost]
        [Authorize(Roles = Constants.Admin)]
        public IActionResult AddCounty(string county)
        {
            if (!currentUser.CanCreateCities)
                return AccessDenied();

            if (countyService.Add(county))
                return Ok();

            return NotFound();
        }
    }
}