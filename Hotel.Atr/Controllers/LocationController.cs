using Hotel.Atr.BLL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Atr.Controllers
{
    public class LocationController : Controller
    {
        // GET: LocationController
        public ActionResult Index()
        {
            LocationService locationService = new LocationService();
            return View(locationService.GetLocations());
        }
        public ActionResult LocationDetails(int id)
        {
            LocationService locationService = new LocationService();
            locationService.UpdateViewsLocation(id);
            return View(locationService.GetLocation(id));
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
