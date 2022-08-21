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
                            CropID = product.ProductID, CropName = product.ProductName, CropCategory = product.ProductCategory,
                            QuantityOnHand = product.QuantityOnHand, ImageURL = product.ImageURL, UserID = product.UserID,
                            CostPrice = Convert.ToDouble(product.CostPrice),
                        };
                        cropList.Add(food);


                    }
                    else if (product.ProductCategory == "Oil")
                    {
                        Oil oil = new Oil()
                        {
                            CropID = product.ProductID,CropName = product.ProductName, CropCategory = product.ProductCategory,
                            QuantityOnHand = product.QuantityOnHand, ImageURL = product.ImageURL, UserID = product.UserID,
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
            var item = GetType(id, category);
            if (Session["Cart"] == null)
            {
                 using (AgriMarketEntities context = new AgriMarketEntities())
                {
                    var c = context.Products.Where(a => a.ProductID == id).FirstOrDefault();
                    
                    List<Crop> cartList = new List<Crop>();
                    List<Crop> cartListDuplicate = new List<Crop>();
                    if (cartList.Where(z => z.CropID == id).Count() == 0)
                    {
                        cartList.Add(item);
                        cartListDuplicate.Add(item);
                        Session["Cart"] = cartList;
                        Session["CartD"] = cartListDuplicate;
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
                    

                    List<Crop> cartList = (List<Crop>)Session["Cart"];
                    List<Crop> cartListDuplicate = (List<Crop>)Session["CartD"];
                    var count = cartListDuplicate.Where(z => z.CropID == id).Count() + 1;
                    if (cartList.Where(z => z.CropID == id).Count() > 0)
                    {
                        cartList.RemoveAll(q => q.CropID == id);
                        item.Quantity = count;
                        cartList.Add(item);
                        cartListDuplicate.Add(item);
                        Session["Cart"] = cartList;
                        Session["CartD"] = cartListDuplicate;
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

        public Crop GetType(int id, string category)
        {
            using (AgriMarketEntities context = new AgriMarketEntities())
            {
                var c = context.Products.Where(a => a.ProductID == id).FirstOrDefault();
                if (category == "Food")
                {
                    Food f = new Food()
                    {
                        CropID = c.ProductID,
                        CropName = c.ProductName,
                        CropCategory = c.ProductCategory,
                        QuantityOnHand = c.QuantityOnHand,
                        ImageURL = c.ImageURL,
                        UserID = c.UserID,
                        CostPrice = Convert.ToDouble(c.CostPrice),
                        Quantity = 1
                    };
                    return f;
                }
                else if (category == "Oil")
                {
                    Oil o = new Oil()
                    {
                        CropID = c.ProductID,
                        CropName = c.ProductName,
                        CropCategory = c.ProductCategory,
                        QuantityOnHand = c.QuantityOnHand,
                        ImageURL = c.ImageURL,
                        UserID = c.UserID,
                        CostPrice = Convert.ToDouble(c.CostPrice),
                        Quantity = 1
                    };
                    return o;
                }

            }
            Food d = new Food();
            return d;
        }



    }
}