ImageService 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gallery.Domian.Entities;
using Gallery.Persistance;
using Gallery.ServicesInerfaces;
using Microsoft.EntityFrameworkCore;

namespace Gallery.Services
{
    public class ImageService : IImageService
    {
        private readonly IDbContextFactory<GalleryContext> _contextFactory;



        public ImageService(IDbContextFactory<GalleryContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task Save(Image image)
        {
            using var db = _contextFactory.CreateDbContext();

            var tmp = db.Images.FirstOrDefault(x => x.id == image.id);

            if (tmp == null)
            {
                db.Images.Add(image);
                await db.SaveChangesAsync();
            }

        }



        public async Task Update(Image image)
        {

            using var db = (_contextFactory.CreateDbContext());

            var tmp = db.Images.FirstOrDefault(x => x.id == image.id);

            if (tmp != null)
            {
                tmp.title = image.title;
                tmp.description = image.description;
                tmp.updatedAt = image.updatedAt;


                await db.SaveChangesAsync();
            }
        }
        public async Task Delete(Image image)

        {
            using var db = _contextFactory.CreateDbContext();

            var tmp = db.Images.FirstOrDefault(x => x.id == image.id);

            if (tmp != null)
            {
                db.Images.Remove(tmp);
                await db.SaveChangesAsync();
            }
        }
        public async Task<Image> Get(int id)
        {
            using var db = _contextFactory.CreateDbContext();

            var image = await db.Images.FirstOrDefaultAsync(x => x.id == id);
            return image;
        }
        public async Task<List<Image>> GetList(string title)
        {
            using var db = _contextFactory.CreateDbContext();

            var images = await db.Images.Where(x => x.title.Contains(title)).ToListAsync();
            return db.Images.ToList();
        }

        public async Task<List<Image>> GetAll()
        {
            using var db = _contextFactory.CreateDbContext();

            return await db.Images.ToListAsync();
        }


    }
}
GalService////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gallery.Domian.Entities;
using Gallery.Persistance;
using Gallery.ServicesInerfaces;
using Microsoft.EntityFrameworkCore;

namespace Gallery.Services
{

    public class GalService : IGalrService
    {
        private readonly IDbContextFactory<GalleryContext> _contextFactory;

        

        public GalService(IDbContextFactory<GalleryContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Save(Gal gal)
        {
            using var db = _contextFactory.CreateDbContext();

            var tmp = db.Gals.FirstOrDefault(x => x.id == gal.id);

            if (tmp == null)
            {
                db.Gals.Add(gal);
                await db.SaveChangesAsync();
            }
        }
        public async Task Update(Gal gal)
        {
            using var db = _contextFactory.CreateDbContext();

            var tmp = db.Gals.FirstOrDefault(y => y.id == gal.id);

            if (tmp != null)
            {
                tmp.name = gal.name;
                tmp.description = gal.description;
                tmp.updatedAt = gal.updatedAt;

                await db.SaveChangesAsync();
            }
        }
        public async Task<Gal> Get(int id)
        {
            using var db = _contextFactory.CreateDbContext();

            var gal = await db.Gals.FirstOrDefaultAsync(x => x.id == id);
            return gal;
        }
        public async Task<List<Gal>> GetAll()
        {
            using var db = _contextFactory.CreateDbContext();

            return await db.Gals.ToListAsync();
        }

        public async Task Delete(Gal gal)
        {
            using var db = _contextFactory.CreateDbContext();

            var tmp = db.Gals.FirstOrDefault(x => x.id == gal.id);
            if (tmp != null)
            {
                db.Gals.Remove(tmp);
                await db.SaveChangesAsync();
            }
        }

        public async Task<List<Gal>> GetList(string name)
        {
            using var db = _contextFactory.CreateDbContext();

            var images = await db.Images.Where(x => x.title.Contains(name)).ToListAsync();
            return db.Gals.ToList();
        }
    }
}
    IImageService/////////////////
    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gallery.Domian.Entities;


namespace Gallery.ServicesInerfaces
{
    public interface IBookService
    {
        Task Delete(Image image);
        Task<Image> Get(int id);
        Task<List<Image>> GetList(string title);
        Task Save(Image image);
        Task Update(Image image);
        Task<List<Image>> GetAll();
        
    }
}
IGalService/////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gallery.Domian.Entities;

namespace Gallery.ServicesInerfaces
{
    
    public interface IGalrService
    {
        Task Delete(Gal gal);
        Task<Gal> Get(int id);
       
        Task<List<Gal>> GetAll();
        Task Save(Gal gal);
        Task Update(Gal gal);
        Task<List<Gal>> GetList(string name);

    }
}

