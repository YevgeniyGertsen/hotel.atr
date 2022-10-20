using Hotel.Atr.EF.BLL;
using Hotel.ATR.EF.BLL.Model;

namespace Hotel.ATR.EF.BLL.Interfaces
{
    public interface IServiceRoom
    {
        List<Room> GetRooms();
        Room GetRoom(Guid roomId);
        bool CheckAvailability(Guid roomId, DateTime startDate, DateTime endDate, out string status);
        ReturnResult BookingRoom(Availabilty availabilty);
    }
}
