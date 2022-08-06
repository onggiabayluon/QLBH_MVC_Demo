using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLBHLuongDucHuy.Models;


namespace QLBHLuongDucHuy.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        NorthwindDataContext da = new NorthwindDataContext();
        // List: Product
        public ActionResult ListProduct()
        {
            List<Product> products = da.Products.Select(p => p).ToList();


            return View(products);
        }

    }
}