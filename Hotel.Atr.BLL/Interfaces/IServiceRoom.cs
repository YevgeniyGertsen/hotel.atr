using Hotel.Atr.BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Atr.BLL.Interfaces
{
    public interface IServiceRoom
    {
        List<Room> GetRooms();
        Room GetRoom(Guid roomId);
        bool CheckAvailability(Guid roomId, DateTime startDate, DateTime endDate, out string status);
        ReturnResult BookingRoom(Availabilty availabilty);
    }
}
