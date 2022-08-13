using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLBHLuongDucHuy.Models;

namespace QLBHLuongDucHuy.Controllers
{
    public class CartController : Controller
    {
        private NorthwindDataContext da = new NorthwindDataContext();
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        public int Count(int count = 0)
        {
            List<Cart> carts = Session["Cart"] as List<Cart>;
            if (carts != null)
            {
                count = carts.Sum(s => s.Quantity);
            }
            
            return count;
        }
        public decimal Total(decimal total = 0)
        {
            List<Cart> carts = Session["Cart"] as List<Cart>;
            if (carts != null)
            {
                total = carts.Sum(s => s.Total);
            }

            return total;
        }

        // List: Cart
        public ActionResult ListCarts()
        {
            List<Cart> carts = GetListCarts();

            if (carts.Count == 0)
            {
                return RedirectToAction("ListProduct", "Product");
            }
            ViewBag.CountProduct = Count();
            ViewBag.Total = Total();

            return View(carts);
        }

        // GetCart List 
        public List<Cart> GetListCarts() // lấy ds giỏ hàng
        {
            List<Cart> carts = Session["Cart"] as List<Cart>;

            if (carts == null)
            {
                carts = new List<Cart>();
                Session["Cart"] = carts;
            }

            return carts;
        }

        public ActionResult addCart(int id) 
        {
            List<Cart> carts = GetListCarts(); // Lấy DS GH

            Cart cart = carts.Find(c => c.productID == id);

            if (cart == null)
            {
                cart = new Cart(id); // Tạo SPGH mới
                carts.Add(cart);
            }
            else
            {
                cart.Quantity++;
            }

            return RedirectToAction("ListCarts");
        }
        public ActionResult Delete(int id)
        {
            List<Cart> carts = GetListCarts(); // Lấy DS GH
            Cart c = carts.Find(s => s.productID == id);
            if (c != null)
            {
                carts.RemoveAll(s => s.productID == id);
            }
            if (carts.Count == 0)
            {
                return RedirectToAction("ListProduct", "Product");
            }

            return RedirectToAction("ListCarts");
        }
    }
}