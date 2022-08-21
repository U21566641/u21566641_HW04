using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using u21566641_HW04.Models;

namespace u21566641_HW04.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]//Register the user
        [ValidateAntiForgeryToken]
        public ActionResult Registration(User user)
        {
            bool status = false;
            string message = "";

            if (ModelState.IsValid)
            {
                //Check if email already exists, give appropriate error message if it does
                var doesExist = doesEmailExist(user.EmailAddress);
                if(doesExist)
                {
                    ModelState.AddModelError("EmailExists", "Email already exists");
                    return View(user);
                }


                //Hash the password(s)
                user.Password = Cryptography.Hash(user.Password);
                user.ConfirmPassword = Cryptography.Hash(user.ConfirmPassword);


                //Save to database
                using(AgriMarketEntities dc = new AgriMarketEntities())
                {
                    dc.Users.Add(user);
                    dc.SaveChanges();

                    message = "Successfully registered.";
                    status = true;
                }

            }
            else
            {
                message = "Invalid Request";
            }

            ViewBag.StatusMessage = message;
            ViewBag.Status = status;
            ViewBag.message = message;
            return View(user);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin login, String returnUrl="")
        {
            string message = "";

            using(AgriMarketEntities dc = new AgriMarketEntities())
            {
                var v = dc.Users.Where(a => a.EmailAddress == login.EmailAddress).FirstOrDefault();
                if(v != null)
                {
                    if (string.Compare(Cryptography.Hash(login.Password), v.Password)==0)
                    {
                        int timeout = login.RememberMe ? 525600 : 1; //timeout time for cookie based on rememberMe
                        var ticket = new FormsAuthenticationTicket(login.EmailAddress, login.RememberMe, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);

                        if (Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        message = "Invalid login details";
                    }
                }
                else
                {
                    message = "Invalid login details";
                }
            }
            ViewBag.StatusMessage = message;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }

        [NonAction]
        public bool doesEmailExist(string EmailAddress)
        {
            using (AgriMarketEntities dc = new AgriMarketEntities())
            {
                var v = dc.Users.Where(a => a.EmailAddress == EmailAddress).FirstOrDefault();
                return v != null;
            }
        }
    }

    

}