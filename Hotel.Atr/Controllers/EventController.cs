using Hotel.Atr.BLL.Model;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Atr.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            EventService eventService = new EventService();
            List<Event> data = eventService.GetEvents();
            ViewBag.Categories = eventService.UniqumCategories();

            var data_id = RouteData.Values["id"];
            return View(data);
            
        }
    }
}
