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
        public static List<Crop> cropList = new List<Crop>();

        // GET: Market
        [HttpGet]
        public ActionResult Market()
        {
            
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

        
       
    }
}