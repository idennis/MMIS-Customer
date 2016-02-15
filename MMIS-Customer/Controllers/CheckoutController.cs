using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MMIS_Customer.Models;

namespace MMIS_Customer.Controllers
{
    public class CheckoutController : Controller
    {
        private s3471480_MagicInventoryEntities db = new s3471480_MagicInventoryEntities();

        [Authorize]
        public ActionResult Index()
        {
            Cart cart = (Cart)Session["cart"];
            UpdateStoreQuantity();
            return View(cart);
        }

        public ActionResult UpdateStoreQuantity()
        {
            Cart cart = (Cart) Session["cart"];
 
            foreach(ProductStock cartProductStock in cart.CustomerPurchaseItems)
            {
                // Look up the actual product stock from the database.
                ProductStock productStock = db.ProductStocks.Find(cartProductStock.ProductID, cartProductStock.StoreID);
 
                // Change the quantity in the database.
                productStock.Quantity -= cartProductStock.Quantity;
            }
 
            // Update database 
            db.SaveChanges();
 
            // Reset cart.
            Session["cart"] = new Cart();
           

            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
