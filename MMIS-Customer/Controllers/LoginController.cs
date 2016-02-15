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
    public class LoginController : Controller
    {
        private s3471480_MagicInventoryEntities db = new s3471480_MagicInventoryEntities();

        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ActionName("Index")]
        public ActionResult LogInPost([Bind(Include = "CustomerUN, CustomerPW")] Customer customer)
        {
            using (s3471480_MagicInventoryEntities database = new s3471480_MagicInventoryEntities())
            {
                Customer login = database.Customers.FirstOrDefault(u => u.CustomerUN == customer.CustomerUN &&
                                                                        u.CustomerPW == customer.CustomerPW);
                if (login != null)
                {
                    Session["Username"] = login.CustomerUN;
                    Session["Password"] = login.CustomerPW;
                    return RedirectToAction("Index", "Checkout");
                    //return RedirectToAction("Index", "Products");
                }
                else
                {
                    Response.Write("Invalid");
                }
            }

            return View(customer);
        }


        public ActionResult Logout()
        {
            Session["Username"] = null;
            Session["Password"] = null;
            return RedirectToAction("Index", "Login");
        }






        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
