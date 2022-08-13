using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using u21566641_HW04.Models;

namespace u21566641_HW04.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult CropRegistration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CropRegistration(Crop crop)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}