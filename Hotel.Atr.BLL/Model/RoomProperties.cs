using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Atr.BLL.Model
{
    public class RoomProperties
    {
        public int RoomPropertiesId { get; set; }
        public string NamePropery { get; set; }
        public string ValuePropery { get; set; }
        public int RoomId { get; set; }
        
    }
}
