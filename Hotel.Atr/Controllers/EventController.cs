using Hotel.Atr.BLL.Model;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Atr.Controllers
{

    //[Route("[controller]")]
    //[Route("news/main")]
    //[Route("zanaliktar")]
    //[Route("novosty")]
    public class EventController : Controller
    {
        //[Route("News/all")]
        //[Route("")]
        //[Route("[action]")]
        public IActionResult Index()
        {
            EventService eventService = new EventService();
            List<Event> data = eventService.GetEvents();
            ViewBag.Categories = eventService.UniqumCategories();

            var data_id = RouteData.Values["id"];
            return View(data);
        }

        [Route("period/{year:int}/{month:int}/{day:int}")]
        public IActionResult IndexPeriod(int year, int month, int day)
        {
            EventService eventService = new EventService();
            List<Event> data = eventService.GetEvents();
            ViewBag.Categories = eventService.UniqumCategories();

            var data_id = RouteData.Values["id"];
            return View(data);
        }
    }
}
