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
    