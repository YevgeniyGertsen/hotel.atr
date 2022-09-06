using Hotel.Atr.BLL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Hotel.Atr.Controllers
{
    public class RoomController : Controller
    {
        private ServiceRoom serviceRooms = new ServiceRoom();

        // GET: RoomController
        public ActionResult Index()
        {
            return View(serviceRooms.GetRooms());
        }

        public ActionResult RoomList()
        {
            return View(serviceRooms.GetRooms());
        }

        public ActionResult RoomDetails(Guid roomId, string availabilityRoom="")
        {
            return View(serviceRooms.GetRoom(roomId));
        }   
        
        [HttpPost]
        public ActionResult CheckAvailability(string arrive)
        {
            Guid roomId = Guid.Empty;
            string availabilityRoom = "";


            return RedirectToAction("RoomDetails", new { roomId, availabilityRoom });
        }
    }
}
