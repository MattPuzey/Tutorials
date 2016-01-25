using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using System.Security.Claims;
using Microsoft.AspNet.Authorization;

namespace MovieAngularJSApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            var user = (ClaimsIdentity)User.Identity;
            ViewBag.Name = user.Name;
            ViewBag.CanEdit = user.FindFirst("CanEdit") != null ? "true" : "false";
            return View();
        }
    }
}

