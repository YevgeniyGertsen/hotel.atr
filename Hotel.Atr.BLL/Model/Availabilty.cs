using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Atr.BLL.Model
{
    public class Availabilty
    {
        public Availabilty(DateTime start,DateTime end, Guid roomId)
        {
            ReservationStart = start;
            ReservationEnd = end;
            ServiceRoom serviceRoom = new ServiceRoom();

            RoomId = serviceRoom.GetRoom(roomId).RoomId;
        }
        public Availabilty()
        {
        }
        public int AvailabiltyId { get; set; }
        public DateTime ReservationStart { get; set; }
        public DateTime ReservationEnd { get; set; }

        public Room Room { get; set; }
        public int RoomId { get; set; }

        public double ReservationTotalDays { get { return (ReservationEnd - ReservationStart).TotalDays; } }
    }
}
