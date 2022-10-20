using Hotel.ATR.EF.BLL.Interfaces;
using Hotel.ATR.EF.BLL.Model;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Atr.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService _service;

        public EventController(IEventService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            List<Event> data = _service.GetEvents();
            ViewBag.Categories = _service.UniqumCategories();

            var data_id = RouteData.Values["id"];
            return View(data);
        }

        [Route("period/{year:int}/{month:int}/{day:int}")]
        public IActionResult IndexPeriod(int year, int month, int day)
        {
            List<Event> data = _service.GetEvents();
            ViewBag.Categories = _service.UniqumCategories();

            var data_id = RouteData.Values["id"];
            return View(data);
        }
    }
}
