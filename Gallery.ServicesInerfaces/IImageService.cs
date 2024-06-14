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
