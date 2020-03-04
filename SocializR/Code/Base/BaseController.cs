using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocializR.Code.Settings;

namespace SocializR.Code
{
    public class BaseController : Controller
    {
        protected readonly AppSettings settings;
        protected readonly IMapper mapper;

        public BaseController(AppSettings settings, IMapper mapper)
            : base()
        {
            this.settings = settings;
            this.mapper = mapper;
        }

        public BaseController(AppSettings settings)
            : base()
        {
            this.settings = settings;
        }

        public BaseController()
            :base()
        {

        }

        public BaseController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        protected IActionResult NotFoundView()
        {
            return View("NotFound");
        }

        protected IActionResult InternalServerErrorView()
        {
            return View("InternalServerError");
        }

        protected IActionResult AccessDenied()
        {
            return View("AccessDenied");
        }
    }
}
