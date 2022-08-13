using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QLBHLuongDucHuy.Models;

namespace QLBHLuongDucHuy.Models
{
    public class Cart
    {
        private NorthwindDataContext da = new NorthwindDataContext();

        public int productID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get { return UnitPrice * Quantity; } }

        public Cart(int productID)
        {
            this.productID = productID;
            Product p = da.Products.Single(n => n.ProductID == productID);
            ProductName = p.ProductName;
            UnitPrice = (decimal)p.UnitPrice;
            Quantity = 1;
        }
    }
}