using System;
using System.Collections.Generic;

namespace Hotel.ATR.EF.BLL.Model
{
    public partial class Room
    {
        public Room()
        {
            Pictures = new HashSet<Picture>();
        }

        public int RoomId { get; set; }
        public Guid RoomGuid { get; set; }
        public bool Status { get; set; }
        public int Floor { get; set; }
        public int Level { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;


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

        public Picture GetMainPicture
        {
            get
            {
                if (this.Pictures == null)
                {
                    return new Picture("/");
                }
                else
                {
                    return Pictures?.FirstOrDefault(f => f.MainPicture);
                }
            }
        }

        public string ShortDescription()
        {
            return Description.Substring(0, 30) + "...";
        }


        public virtual ICollection<Availabilty> Availabilties { get; set; }

        public virtual ICollection<RoomProperty> RoomProperties { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }
    }
}
