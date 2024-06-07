using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.Domian.Entities
{
    public class Image
    {
        public int id { get; set; }
        [MaxLength(60)]
        public string title { get; set; }
        [MaxLength(300)]
        public string description { get; set; }
        [MaxLength(60)]
        public string fileUBL { get; set; }
        
        public DateTime createdAt { get; set; }
        
        public DateTime updatedAt { get; set; }
        public List<Gal> Gals { get; set; }
    }
}
