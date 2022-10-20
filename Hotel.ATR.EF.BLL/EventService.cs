using Hotel.ATR.EF.BLL.Interfaces;
using Hotel.ATR.EF.BLL.Data;
using Hotel.ATR.EF.BLL.Model;

namespace Hotel.ATR.EF.BLL
{
    public class EventService : IEventService
    {
        private readonly HotelAtrDbContext db;

        public EventService(HotelAtrDbContext _db)
        {
            db = _db;
        }


        public List<Event> GetEvents()
        {
            List<Event> data = db.Events.ToList();

            return data;
        }

        public Event GetEvent(int eventId)
        {
            Event data = db.Events.FirstOrDefault(f => f.EventId == eventId);

            return data;
        }

        /// <summary>
        /// Метод возврощающий уникальный категории, 
        /// для существующих событий
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> UniqumCategories()
        {
            Dictionary<string, string> eventCategories =
                db.Events.Select(x => new
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