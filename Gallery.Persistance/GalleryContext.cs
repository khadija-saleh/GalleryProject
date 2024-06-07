using Microsoft.EntityFrameworkCore;
using Gallery.Domian.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.Persistance
{
    public class GalleryContext : DbContext
    {
        public GalleryContext(DbContextOptions<GalleryContext> options):
             base(options) { }
        
           
        public DbSet<Gal> Gals { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
