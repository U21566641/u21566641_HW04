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
        [Authorize(Roles ="Supplier")]
        public ActionResult ProductRegistration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CropRegistration(Crop crop)
        {
            return RedirectToAction("Index", "Home");
        }
        //Assigns Supplier role to user
        [HttpPost]
        public ActionResult AssignRole(UsersRoleProvider usersRole, String emailAddress)
        {

             using (AgriMarketEntities context = new AgriMarketEntities())
             {
                var email = User.Identity.Name;
                var id = context.Users.Where(a => a.EmailAddress == email).Select(a => a.UserId).FirstOrDefault();
                var updated = new UserRole { UserID = id, RoleID = 3 };
                context.UserRoles.Add(updated);
                context.SaveChanges();
            
            }
                return RedirectToAction("Index", "Home");
        }
    }
}