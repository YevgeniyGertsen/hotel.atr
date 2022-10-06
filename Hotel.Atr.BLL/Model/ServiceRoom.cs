using Dapper;
using Hotel.Atr.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Atr.BLL.Model
{
    public class ServiceRoom : IServiceRoom
    {
        private readonly IRepository<Room> _repo;
        private readonly IRepository<Picture> _repoPic;
        private readonly IRepository<RoomProperties> _repoProp;
        private readonly IRepository<Availabilty> _repoAvl;

        public ServiceRoom(IRepository<Room> repo,
            IRepository<Picture> repoPic,
            IRepository<RoomProperties> repoProp,
            IRepository<Availabilty> repoAvl)
        {
            _repo = repo;
            _repoPic = repoPic;
            _repoProp = repoProp;
            _repoAvl = repoAvl;
        }


        public List<Room> GetRooms()
        {
            List<Room> data = new List<Room>();
            try
            {
                data = _repo.Get();

                foreach (Room room in data)
                {
                    room.Pictures = _repoPic.Get()
                                    .Where(w => w.RoomId == room.RoomId)
                                    .ToList();

                    room.RoomProperties = _repoProp.Get()
                                    .Where(w => w.RoomId == room.RoomId)
                                    .ToList();
                }
            }
            catch (Exception ex)
            {

            }

            return data;
        }

        public Room GetRoom(Guid roomId)
        {
            Room room = null;
            try
            {
                room = _repo.GetItemById(roomId);
                room.RoomProperties = _repoProp
                    .Get()
                    .Where(w => w.RoomId == room.RoomId).ToList();
            }
            catch
            {

            }

            return room;
        }

        public bool CheckAvailability(Guid roomId, DateTime startDate, DateTime endDate, out string status)
        {
            bool result = false;
            try
            {
                var room = _repo.GetItemById(roomId);

                //получаем список броней
                var availabilties =
                   _repoAvl.Get()
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
                _repoAvl.Create(availabilty, 
                    "ReservationStart", 
                    "ReservationEnd", 
                    "RoomId");

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
