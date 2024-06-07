using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.Domian.Entities
{
    public class Gal
    {
        public int id { get; set; }
        [MaxLength(60)]
        public string name { get; set; }
        [MaxLength(300)]
        public string description { get; set; }
        
        public DateTime createdAt { get; set; }
       
        public DateTime updatedAt { get; set; }
        
        public List<Image> Images { get; set; }
    }
}
