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
                            new { RoomId  = room.RoomId}).ToList();

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
    }
}
