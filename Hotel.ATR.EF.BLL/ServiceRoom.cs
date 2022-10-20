using Hotel.Atr.EF.BLL;
using Hotel.ATR.EF.BLL.Data;
using Hotel.ATR.EF.BLL.Interfaces;
using Hotel.ATR.EF.BLL.Model;
using Microsoft.EntityFrameworkCore;

namespace Hotel.ATR.EF.BLL
{
    public class ServiceRoom : IServiceRoom
    {
        private readonly HotelAtrDbContext db;

        public ServiceRoom(HotelAtrDbContext _db)
        {
            db = _db;
        }

        public List<Room> GetRooms()
        {
            List<Room> data = db.Rooms
                .Include(u=>u.Availabilties)
                .Include(u=>u.RoomProperties)
                .Include(u=>u.Pictures)
                .ToList();

            return data;
        }

        public Room GetRoom(Guid roomId)
        {
            Room room = db.Rooms.Include(u => u.Availabilties)
                .Include(u => u.RoomProperties)
                .Include(u => u.Pictures).FirstOrDefault(f => f.RoomGuid == roomId);

            return room;
        }

        public bool CheckAvailability(Guid roomId, DateTime startDate, DateTime endDate, out string status)
        {
            bool result = false;
            try
            {
                var room = GetRoom(roomId);

                //получаем список броней
                var availabilties =
                   db.Availabilties
                   .Where(w => w.RoomId == room.RoomId
                          && DateTime.Now > w.ReservationStart);

                //проверим доступна ли комната на выбранный период
                if (availabilties.Any(a => startDate > a.ReservationStart
                                      && startDate < a.ReservationEnd))
                {
                    status = "Номер на выбранные период не доступен";
                    result = false;
                }
                else
                {
                    status = "Номер на выбранные период доступен";
                    result = true;
                }
            }
            catch (Exception ex)
            {
                status = "При проверки доступности возникла ошибка (" + ex.Message + ")";
                result = false;
            }

            return result;
        }

        public ReturnResult BookingRoom(Availabilty availabilty)
        {
            ReturnResult result = new ReturnResult();

            try
            {
                db.Availabilties.Add(availabilty);
                db.SaveChanges();

                result.Result = true;
                result.Message = "OK";
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Message = ex.Message;
            }

            return result;
        }
    }
}