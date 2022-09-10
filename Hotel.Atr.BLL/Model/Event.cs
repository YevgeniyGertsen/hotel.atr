using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Atr.BLL.Model
{
    public enum Size
    {
        Small,
        Big
    }
    public class Event
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string ShortDescription
        {
            get
            {
                return Description.Substring(0, 30);
            }
        }
        public Size Size { get; set; }
        public DateTime CreateDate { get; set; }
        public string ImagePath { get; set; }
        public DateTime ExparyDate { get; set; }
        public string ContentEvent { get; set; }
        public EventCategory EventCategory { get; set; }
        public int EventCategoryId { get; set; }
        public string EventStyle
        {
            get
            {
                if (Size == Size.Small)
                {
                    return "col-md-4 small col-sm-4";
                }
                else
                {
                    return "col-md-8 col-sm-8";
                }
            }
        }
    }
}
