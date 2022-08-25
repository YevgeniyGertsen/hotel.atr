using Hotel.Atr.BLL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Hotel.Atr.Controllers
{
    public class RoomController : Controller
    {
        // GET: RoomController
        public ActionResult Index()
        {
            ServiceRoom serviceRooms = new ServiceRoom();

            return View(serviceRooms.GetRooms());
        }

        public ActionResult RoomList()
        {
            ServiceRoom serviceRooms = new ServiceRoom();

            return View(serviceRooms.GetRooms());
        }

        public ActionResult RoomDetails(Guid roomId)
        {
            return View();
        }
    }
}
