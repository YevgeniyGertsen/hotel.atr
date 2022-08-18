using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Atr.Controllers
{
    public class RoomController : Controller
    {
        // GET: RoomController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RoomList()
        {
            return View();
        }

        public ActionResult RoomDetails()
        {
            return View();
        }
    }
}
