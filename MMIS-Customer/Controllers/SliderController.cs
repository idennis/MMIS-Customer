using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MMIS_Customer.Models;

namespace MMIS_Customer.Controllers
{
    public class SliderController : Controller
    {
        // GET: Slider
        public ActionResult Index()
        {
            using (GalleryDbContext db = new GalleryDbContext())
            {
                return View(db.gallery.ToList());
            }
            //return View();
        }


        // Add Images in slider.
        public ActionResult AddImage()
        {
            return View();
        }

        // This method gets called when we have selected the image and post it back to the server.
        [HttpPost]
        public ActionResult AddImage(HttpPostedFileBase ImagePath)
        {
            if (ImagePath != null)
            {
                
                System.Drawing.Image img = System.Drawing.Image.FromStream(ImagePath.InputStream);

                // Disabled image size constraints
                //if ((img.Width != 800) || (img.Height != 356))
                //{
                //    ModelState.AddModelError("", "Image resolution must be 800 x 356 pixels");
                //    return View();
                //}

                // Upload your pic to a folder on your server.
                string pic = System.IO.Path.GetFileName(ImagePath.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/Content/images"), pic);
                ImagePath.SaveAs(path);

                // Save the URL of the new image to your database
                using (GalleryDbContext db = new GalleryDbContext())
                {
                    Gallery gallery = new Gallery { ImagePath = "~/Content/images/" + pic };
                    db.gallery.Add(gallery);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        // Delete Multiple Images
        public ActionResult DeleteImages()
        {
            using (GalleryDbContext db = new GalleryDbContext())
            {
                return View(db.gallery.ToList());
            }
        }

        [HttpPost]
        public ActionResult DeleteImages(IEnumerable<int> ImagesIDs)
        {
            using (GalleryDbContext db = new GalleryDbContext())
            {
                foreach (var id in ImagesIDs)
                {
                    // Retrieve an image
                    var image = db.gallery.Single(s => s.ID == id);

                    // Delete the image from the server and database
                    string imgPath = Server.MapPath(image.ImagePath);
                    db.gallery.Remove(image);

                    if (System.IO.File.Exists(imgPath))
                    {
                        System.IO.File.Delete(imgPath);
                    }
                }
                db.SaveChanges();
            }
            return RedirectToAction("DeleteImages");
        }
    }
}