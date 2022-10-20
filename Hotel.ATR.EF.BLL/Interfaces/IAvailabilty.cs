using Hotel.ATR.EF.BLL.Model;

namespace Hotel.ATR.EF.BLL.Interfaces
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
