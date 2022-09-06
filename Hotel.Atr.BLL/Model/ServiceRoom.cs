using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Atr.BLL.Model
{
    public class ServiceRoom
    {
        string connectionString = @"Server=223-17\MSSQLSERVER99;Database=ATR;Trusted_Connection=True;";
        public List<Room> GetRooms()
        {
            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    db.Open();

                    List<Room> data = db.Query<Room>
                        ("SELECT * FROM Room ")
                        .ToList();


                    foreach (Room room in data)
                    {
                        room.Pictures = db.Query<Picture>("SELECT * FROM Picture where RoomId=@RoomId",
                            new { RoomId = room.RoomId }).ToList();

                        room.RoomProperties = db.Query<RoomProperties>("SELECT * FROM RoomProperties where RoomId=@RoomId",
                            new { RoomId = room.RoomId }).ToList();
                    }

                    return data;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Room GetRoom(Guid roomId)
        {
            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    db.Open();

                    Room room = db.QueryFirstOrDefault<Room>
                        ("SELECT * FROM Room where RoomGuid = @RoomGuid",
                        new { RoomGuid = roomId });


                    room.RoomProperties =
                        db.Query<RoomProperties>("SELECT * FROM RoomProperties where RoomId=@RoomId",
                        new { RoomId = room.RoomId }).ToList();

                    return room;
                }
            }
            catch
            {
                return null;
            }
        }


        public bool CheckAvailability(Guid roomId, DateTime startDate, DateTime endDate, out string status)
        {
            bool result = false;
            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    db.Open();

                    var room = db.QueryFirstOrDefault<Room>("SELECT * FROM Room where RoomGuid = @RoomGuid",
                        new { RoomGuid = roomId });

                    //получаем список броней
                    var availabilties =
                        db.Query<Availabilty>("SELECT * FROM Availabilty where RoomId = @RoomId",
                        new { RoomId = room.RoomId }).Where(w => DateTime.Now > w.ReservationStart);

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
            }
            catch (Exception ex)
            {
                status = "При проверки доступности возникла ошибка ("+ex.Message+")";
                result = false;
            }

            return result;
        }
    }
}
