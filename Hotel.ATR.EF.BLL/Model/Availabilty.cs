using System;
using System.Collections.Generic;

namespace Hotel.ATR.EF.BLL.Model
{
    public partial class Availabilty
    {
        public Availabilty()
        {

        }
        public Availabilty(DateTime start, DateTime end, Guid roomId)
        {
            ReservationStart = start;
            ReservationEnd = end;
        }

        public int AvailabilityId { get; set; }
        public DateTime ReservationStart { get; set; }
        public DateTime ReservationEnd { get; set; }
        public int RoomId { get; set; }

        public virtual Room Room { get; set; }      
    }
}