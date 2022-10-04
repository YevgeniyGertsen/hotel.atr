using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using Hotel.Atr.BLL.Interfaces;

namespace Hotel.Atr.BLL.Model
{
    public class EventService : IEventService
    {
        private readonly IRepository<Event> _repo;
        private readonly IRepository<EventCategory> _repoCategory;

        public EventService(IRepository<Event> repo, 
            IRepository<EventCategory> repoCategory)
        {
            _repo = repo;
            _repoCategory = repoCategory;
        }

        public List<Event> GetEvents()
        {
            try
            {
                List<Event> data = _repo.Get();

                foreach (Event item in data)
                    item.EventCategory = _repoCategory
                        .GetItemById(item.EventCategoryId); 

                return data;
            }
            catch
            {
                return null;
            }
        }

        public Event GetEvent(int eventId)
        {
            try
            {
                Event data = _repo.GetItemById(eventId);

                //data.EventCategory = db.QueryFirstOrDefault<EventCategory>("SELECT * FROM EventCategory where EventCategoryId=@EventCategoryId",
                //    new { EventCategoryId = data.EventCategoryId });

                return data;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Метод возврощающий уникальный категории, 
        /// для существующих событий
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> UniqumCategories()
        {
            Dictionary<string, string> eventCategories =
                GetEvents().Select(x => new
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