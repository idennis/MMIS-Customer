using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MMIS_Customer.Models
{
    public class GalleryDbContext : DbContext
    {
        public DbSet<Gallery> gallery { get; set; }
    }
}