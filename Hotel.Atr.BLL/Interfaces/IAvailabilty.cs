using Hotel.Atr.BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Atr.BLL.Interfaces
{
    public interface IAvailabilty
    {
        int AvailabiltyId { get; set; }
        DateTime ReservationStart { get; set; }
        DateTime ReservationEnd { get; set; }
        Room Room { get; set; }
        int RoomId { get; set; }
        double ReservationTotalDays {get;}
    }
}
