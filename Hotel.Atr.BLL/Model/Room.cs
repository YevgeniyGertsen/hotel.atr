using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Atr.BLL.Model
{
    public class Room
    {
        public int RoomId { get; set; }
        public Guid RoomGuid { get; set; }
        public bool Status { get; set; }
        public int Floor { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Discount { get; set; }

        /// <summary>
        ///метод возвращает сумму со скидкой
        /// </summary>
        /// <returns></returns>
        public string WithDiscount()
        {
            return string.Format("{0} kzt", Price-(Price*(Discount/100)));
        }
        /// <summary>
        /// метод возвращает полную стоимость
        /// </summary>
        /// <returns></returns>
        public string NoDiscount()
        {
            return string.Format("{0} kzt", Price);
        }


        public List<RoomProperties> RoomProperties { get; set; }
        public List<Availabilty> Availabilties { get; set; }

    }
}
