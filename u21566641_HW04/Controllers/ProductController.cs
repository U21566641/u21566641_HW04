using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using u21566641_HW04.Models;

namespace u21566641_HW04.Controllers
{
    public class ProductController : Controller
    {
        [Authorize(Roles = "Admin, Supplier")]
        // GET: Product
        [HttpGet]
        public ActionResult ProductRegistration()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult ProductRegistration(Product product, HttpPostedFileBase ImageURL)
        {
            //Takes an ImageURL to save in fileSystem, as only a reference is saved in the DB
            if (ModelState.IsValid)
            {
               if(ImageURL != null)
                {
                    //Save to files
                    var fileName = Path.GetFileName(ImageURL.FileName);
                    var filePath = Server.MapPath(Url.Content("~/Media/Images"));
                    var savePath = Path.Combine(filePath, fileName);
                    ImageURL.SaveAs(savePath);
                    product.ImageURL = fileName;

                }
                //Save to database
                using (AgriMarketEntities context = new AgriMarketEntities())
                {

                    var email = User.Identity.Name;
                    var id = context.Users.Where(a => a.EmailAddress == email).Select(a => a.UserId).FirstOrDefault();
                    product.UserID = id;
                    context.Products.Add(product);
                    context.SaveChanges();
                    return RedirectToAction("Market", "Market");
                    
                }

            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Invalid.");
            }
            return View(product);
        }


    }
}