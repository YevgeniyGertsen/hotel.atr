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
            var rooms = serviceRooms.GetRooms();

            return View(rooms);
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
