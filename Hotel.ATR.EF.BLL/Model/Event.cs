using System;
using System.Collections.Generic;

namespace Hotel.ATR.EF.BLL.Model
{
    public enum SizeEnu
    {
        Small =0,
        Big = 1
    }
    public partial class Event
    {
        public int EventId { get; set; }
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public int? Size { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? ImagePath { get; set; }
        public DateTime? ExparyDate { get; set; }
        public string? ContentEvent { get; set; }
        public int? EventCategoryId { get; set; }

        public string ShortDescription
        {
            get
            {
                return Description.Substring(0, 30);
            }
        }

        public string EventStyle
        {
            get
            {
                if (this.Size == (int)SizeEnu.Small)
                {
                    return "col-md-4 small col-sm-4";
                }
                else
                {
                    return "col-md-8 col-sm-8";
                }
            }
        }
        public virtual EventCategory? EventCategory { get; set; }
    }
}
