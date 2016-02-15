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
    public class CartController : Controller
    {
        private s3471480_MagicInventoryEntities db = new s3471480_MagicInventoryEntities();

        // GET: /Cart/
        public ActionResult Index()
        {
            Cart cart = (Cart) Session["cart"];
            return View(cart);
        }

        [HttpPost]
        public ActionResult AddToCart(int productID, int storeID, int quantity)
        {
            Product product = db.Products.Find(productID);
            Store store = db.Stores.Include(x => x.Location).SingleOrDefault(x => x.StoreID == storeID);
            Cart cart = (Cart) Session["cart"];
            cart.AddToCart(product, store, quantity);
        

            // Redirect to same controller's index.
             return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult RemoveFromCart(int productID, int storeID)
        {
            Product product = db.Products.Find(productID);
            Store store = db.Stores.Include(x => x.Location).SingleOrDefault(x => x.StoreID == storeID);
            Cart cart = (Cart) Session["cart"];
            cart.RemoveFromCart(product, productID);

            return RedirectToAction("Index");
            
        }

        [HttpPost]
        public ActionResult ChangeQuantity(int productID, int storeID, int quantity)
        {
            Product product = db.Products.Find(productID);
            Store store = db.Stores.Include(x => x.Location).SingleOrDefault(x => x.StoreID == storeID);
            Cart cart = (Cart)Session["cart"];
            cart.ChangeQuantity(product, productID, quantity);

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
