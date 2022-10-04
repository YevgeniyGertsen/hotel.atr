using Hotel.Atr.BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Atr.BLL.Interfaces
{
    public  interface IEventService
    {
        List<Event> GetEvents();

        Event GetEvent(int eventId);

        Dictionary<string, string> UniqumCategories();
    }
}
