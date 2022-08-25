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
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Discount { get; set; }

        /// <summary>
        ///метод возвращает сумму со скидкой
        /// </summary>
        /// <returns></returns>
        public string WithDiscount()
        {
            return string.Format("{0} kzt", Price - (Price * (Discount / 100)));
        }
        /// <summary>
        /// метод возвращает полную стоимость
        /// </summary>
        /// <returns></returns>
        public string NoDiscount()
        {
            return string.Format("{0} kzt", Price);
        }


        public List<Availabilty> Availabilties;
        public ICollection<Picture> Pictures { get; set; }
        public ICollection<RoomProperties> RoomProperties { get; set; }

        public Picture GetMainPicture
        {
            get
            {
                if(Pictures == null)
                {
                    return new Picture("/");
                }
                else
                {
                    return Pictures.FirstOrDefault(f => f.MainPicture);
                }
            }
        }

        public string ShortDescription()
        {
            return Description.Substring(0, 30) + "...";
        }

    }
}
