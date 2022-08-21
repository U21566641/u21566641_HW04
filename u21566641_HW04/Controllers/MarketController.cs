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
                    if (product.ProductCategory == "Food")//Checks category and adds relevant obj to list
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
                            CropID = product.ProductID, CropName = product.ProductName, CropCategory = product.ProductCategory,
                            QuantityOnHand = product.QuantityOnHand, ImageURL = product.ImageURL, UserID = product.UserID,
                            CostPrice = Convert.ToDouble(product.CostPrice),
                        };
                        cropList.Add(oil);
                    }
                    else if (product.ProductCategory == "Fiber")
                    {
                        Fiber fiber = new Fiber()
                        {
                            CropID = product.ProductID, CropName = product.ProductName, CropCategory = product.ProductCategory,
                            QuantityOnHand = product.QuantityOnHand, ImageURL = product.ImageURL, UserID = product.UserID,
                            CostPrice = Convert.ToDouble(product.CostPrice),
                        };
                        cropList.Add(fiber);
                    }
                    else if (product.ProductCategory == "Feed")
                    {
                        Feed feed = new Feed()
                        {
                            CropID = product.ProductID, CropName = product.ProductName, CropCategory = product.ProductCategory,
                            QuantityOnHand = product.QuantityOnHand, ImageURL = product.ImageURL, UserID = product.UserID,
                            CostPrice = Convert.ToDouble(product.CostPrice),
                        };
                        cropList.Add(feed);
                            
                    }
                    else if (product.ProductCategory == "Ornamental")
                    {
                        Ornamental ornamental = new Ornamental()
                        { 
                        CropID = product.ProductID, CropName = product.ProductName, CropCategory = product.ProductCategory,
                            QuantityOnHand = product.QuantityOnHand, ImageURL = product.ImageURL, UserID = product.UserID,
                            CostPrice = Convert.ToDouble(product.CostPrice),
                        };
                        cropList.Add(ornamental);
                    }
                    else if (product.ProductCategory == "Industrial")
                    { 
                        Industrial industrial = new Industrial()
                        {
                            CropID = product.ProductID, CropName = product.ProductName, CropCategory = product.ProductCategory,
                            QuantityOnHand = product.QuantityOnHand, ImageURL = product.ImageURL, UserID = product.UserID,
                            CostPrice = Convert.ToDouble(product.CostPrice),
                        };
                        cropList.Add(industrial);
                    }
                }

                return View(cropList);
            }

        }

       
        public ActionResult AddToCart(int id, string category)
        {
            var item = GetType(id, category);//Creates new obj of relevant type to add to cart
            if (Session["Cart"] == null)//Checks if anything in cart of this session
            {
                 using (AgriMarketEntities context = new AgriMarketEntities())
                {
                    var c = context.Products.Where(a => a.ProductID == id).FirstOrDefault();
                    
                    List<Crop> cartList = new List<Crop>();
                    List<Crop> cartListDuplicate = new List<Crop>();//Duplicate list used to keep track
                                                            //Of count of each item
                    if (cartList.Where(z => z.CropID == id).Count() == 0)
                    {
                        cartList.Add(item);
                        cartListDuplicate.Add(item);
                        Session["Cart"] = cartList;
                        Session["CartD"] = cartListDuplicate;
                        
                    }
                    

                }


            }
            else//If cart in session, read what's in the cart and add new items to it
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

        //Determines the category of crop and returns an object of that category
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
                else if (category == "Feed")
                {
                    Feed fe = new Feed()
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
                    return fe;
                }
                else if (category == "Fiber")
                {
                    Fiber fi = new Fiber()
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
                    return fi;
                }
                else if (category == "Ornamental")
                {
                    Ornamental orn = new Ornamental()
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
                    return orn;
                }
                else if (category == "Industrial")
                {
                    Industrial i = new Industrial()
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
                    return i;
                }

            }
            Food d = new Food();
            return d;
        }



    }
}