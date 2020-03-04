using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;

namespace SocializR.Controllers
{
    public class SiteMapController : Controller
    {
        public IActionResult Index()
        {
            return File("test", "text/html");
        }
    }
}