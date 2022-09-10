using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
namespace Hotel.Atr.BLL.Model
{
    public class EventService
    {
        string connectionString = @"Server=223-17\MSSQLSERVER99;Database=ATR;Trusted_Connection=True;";
        public List<Event> GetEvents()
        {
            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    db.Open();

                    List<Event> data = db.Query<Event>
                        ("SELECT * FROM Event ")
                        .ToList();


                    foreach (Event item in data)
                    {
                        item.EventCategory = db.QueryFirstOrDefault<EventCategory>("SELECT * FROM EventCategory where EventCategoryId=@EventCategoryId",
                            new { EventCategoryId = item.EventCategoryId });


                    }

                    return data;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Event GetEvent(int eventId)
        {
            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    db.Open();

                    Event data = db.QueryFirstOrDefault<Event>
                        ("SELECT * FROM Event WHERE EventId=@eventId", new { eventId });
                    data.EventCategory = db.QueryFirstOrDefault<EventCategory>("SELECT * FROM EventCategory where EventCategoryId=@EventCategoryId",
                        new { EventCategoryId = data.EventCategoryId });
                    return data;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Метод возврощающий уникальный категории, для существующих событий
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> UniqumCategories()
        {
            Dictionary<string, string> eventCategories =
                GetEvents()
                .Select(x => new
                {
                    Code = x.EventCategory.Code,
                    Name = x.EventCategory.Name
                })
                .Distinct()
                .ToDictionary(k => k.Code, v => v.Name);
            return eventCategories;
        }
    }
}
