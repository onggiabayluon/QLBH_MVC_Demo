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

        // Detail: Product
        public ActionResult Details(int id)
        {
            Product products = da.Products.Where(p => p.ProductID == id).FirstOrDefault();

            return View(products);
        }

        // Create Page: Product 
        public ActionResult Create()
        {
            ViewData["LSP"] = new SelectList(da.Categories, "CategoryID", "CategoryName");
            ViewData["NCC"] = new SelectList(da.Suppliers, "SupplierID", "CompanyName");
            return View();
        }

        // Create: Product
        [HttpPost]
        public ActionResult Create(Product p, FormCollection form)
        {
            // Change form input name so we need to handle these input seperately
            p.CategoryID = int.Parse(form["LSP"]);
            p.CategoryID = int.Parse(form["NCC"]);

            da.Products.InsertOnSubmit(p);
            da.SubmitChanges();


            return RedirectToAction("ListProduct");
        }

    }
}