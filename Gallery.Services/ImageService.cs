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
