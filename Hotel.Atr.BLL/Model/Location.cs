using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Atr.BLL.Model
{
    public class Location
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Adres { get; set; }
        public int Views { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExparyDate { get; set; }
        public string ImagePath { get; set; }

    }
}
