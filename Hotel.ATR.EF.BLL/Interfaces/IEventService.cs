using Hotel.ATR.EF.BLL.Model;

namespace Hotel.ATR.EF.BLL.Interfaces
{
    public  interface IEventService
    {
        List<Event> GetEvents();

        Event GetEvent(int eventId);

        Dictionary<string, string> UniqumCategories();
    }
}
