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

