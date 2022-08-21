using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using u21566641_HW04.Models;

namespace u21566641_HW04.Controllers
{
    public class MarketController : Controller
    {


        // GET: Market
        [HttpGet]
        public ActionResult Market()
        {
            List<Crop> cropList = new List<Crop>();

            using (AgriMarketEntities context = new AgriMarketEntities())
            {
                var crops = context.Products.ToList();
                foreach (Product product in crops)
                {
                    if (product.ProductCategory == "Food")
                    {
                        Food food = new Food()
                        {
                            CropID = product.ProductID,
                            CropName = product.ProductName,
                            CropCategory = product.ProductCategory,
                            QuantityOnHand = product.QuantityOnHand,
                            ImageURL = product.ImageURL,
                            UserID = product.UserID,
                            CostPrice = Convert.ToDouble(product.CostPrice),
                        };
                        cropList.Add(food);


                    }
                    else if (product.ProductCategory == "Oil")
                    {
                        Oil oil = new Oil()
                        {
                            CropID = product.ProductID,
                            CropName = product.ProductName,
                            CropCategory = product.ProductCategory,
                            QuantityOnHand = product.QuantityOnHand,
                            ImageURL = product.ImageURL,
                            UserID = product.UserID,
                            CostPrice = Convert.ToDouble(product.CostPrice),
                        };
                        cropList.Add(oil);
                    }
                }

                return View(cropList);
            }

        }

       
        public ActionResult AddToCart(int id, string category)
        {
            Food f = new Food();
            if (Session["Cart"] == null)
            {
                 using (AgriMarketEntities context = new AgriMarketEntities())
                {
                    var c = context.Products.Where(a => a.ProductID == id).FirstOrDefault();
                    if (category == "Food")
                    {
                        f = new Food() {

                            CropID = c.ProductID,
                            CropName = c.ProductName,
                            CropCategory = c.ProductCategory,
                            QuantityOnHand = c.QuantityOnHand,
                            ImageURL = c.ImageURL,
                            UserID = c.UserID,
                            CostPrice = Convert.ToDouble(c.CostPrice),
                            Quantity = 1 
                        };

                    }
                    List<Crop> cartList = new List<Crop>();
                   
                    if (cartList.Where(z => z.CropID == id).Count() == 0)
                    {
                        cartList.Add(f);
                        Session["Cart"] = cartList;
                        ViewBag.Cart = cartList.Count();
                        Session["count"] = 1;
                    }
                    

                }


            }
            else
            {
                using (AgriMarketEntities context = new AgriMarketEntities())
                {
                    var c = context.Products.Where(a => a.ProductID == id).FirstOrDefault();
                    if (category == "Food")
                    {
                        f = new Food()
                        {

                            CropID = c.ProductID,
                            CropName = c.ProductName,
                            CropCategory = c.ProductCategory,
                            QuantityOnHand = c.QuantityOnHand,
                            ImageURL = c.ImageURL,
                            UserID = c.UserID,
                            CostPrice = Convert.ToDouble(c.CostPrice),
                            Quantity = 1,
                        };

                    }

                    List<Crop> cartList = (List<Crop>)Session["Cart"];
                    var count = cartList.Where(z => z.CropID == id).Count() + 1;
                    if (cartList.Where(z => z.CropID == id).Count() > 0)
                    {
                        //cartList.RemoveAll(q => q.CropID == id);
                        f.Quantity = count;
                        cartList.Add(f);
                        Session["Cart"] = cartList;
                        ViewBag.Cart = cartList.Count();
                        Session["count"] = 1;
                    }
                }
            }
            return RedirectToAction("Market");
        }

        [HttpGet]
        public ActionResult Cart()
        {
            return View((List<Crop>)Session["Cart"]);
        }


        
       
    }
}