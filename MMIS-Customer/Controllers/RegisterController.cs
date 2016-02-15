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
    public class RegisterController : Controller
    {
        private s3471480_MagicInventoryEntities db = new s3471480_MagicInventoryEntities();

        // Direct user to register page.
        public ActionResult Index()
        {
            return View();
        }


        // Register logic
        [HttpPost]
        [ActionName("Index")]
        public ActionResult RegisterCust(Customer c)
        {
            if (ModelState.IsValid)
            {
                using (db)
                {
                    //checks if the new username being registered already exits
                    Customer customerUserName = db.Customers.Find(c.CustomerUN);
                    //if it exists
                    if (customerUserName != null)
                    {
                        Response.Write("You're already registered. Please login.");
                    }
                    else
                    {

                        db.Customers.Add(c);
                        db.SaveChanges();
                        c = null;
                        Response.Write("Successfully Registration Done");
                    }

                }
            }


            return View(c);
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
