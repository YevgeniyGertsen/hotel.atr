using Hotel.ATR.EF.BLL;
using Hotel.ATR.EF.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Atr.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILocationService _service;

        public LocationController(ILocationService service)
        {
            _service = service;
        }


        // GET: LocationController
        public ActionResult Index()
        {
            return View(_service.GetLocations());
        }
        public ActionResult LocationDetails(int id)
        {
            _service.UpdateViewsLocation(id);
            return View(_service.GetLocation(id));
        }
        [HttpPost]
        public ActionResult SaveUserRequest()
        {
            var fullName = Request.Form["fullName"];
            var fonName = Request.Form["fonName"];
            return RedirectToAction("Index");
        }       
    }
}