using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MMIS_Customer.Models;

namespace MMIS_Customer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (GalleryDbContext db = new GalleryDbContext())
            {
                return View(db.gallery.ToList());
            }

           // return View();
        }
         

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


    }
}