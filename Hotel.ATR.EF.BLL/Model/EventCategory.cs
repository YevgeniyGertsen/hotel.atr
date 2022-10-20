using System;
using System.Collections.Generic;

namespace Hotel.ATR.EF.BLL.Model
{
    public partial class EventCategory
    {
        public EventCategory()
        {
            Events = new HashSet<Event>();
        }

        public int EventCategoryId { get; set; }
        public string? Description { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
