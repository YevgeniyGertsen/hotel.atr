using Hotel.ATR.EF.BLL.Interfaces;
using Hotel.ATR.EF.BLL.Model;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Text;

namespace Hotel.Atr.Controllers
{
    public class RoomController : Controller
    {
        private readonly IServiceRoom _serviceRoom;
        private readonly Availabilty _availabilty;

        public RoomController(IServiceRoom serviceRoom,
             Availabilty availabilty)
        {
            _serviceRoom = serviceRoom;
            _availabilty = availabilty;
        }


        public ActionResult Index()
        {
            ViewBag.Description = "List Room";
            ViewBag.Title = "Room";

            return View(_serviceRoom.GetRooms());
        }
        
        public ActionResult RoomList()
        {
            return View(_serviceRoom.GetRooms());
        }

        public JsonResult RoomListjSON()
        {
            var data = _serviceRoom.GetRooms();
            return Json(data);
        }

        public ContentResult DataForRoom()
        {
            return Content("test", "text/plain", Encoding.Default);
        }

        public FileResult GetRoomReport()
        {
            string filename = @"C:\Users\ГерценЕ\source\repos\WebApplication1\Hotel.Atr\Templates\cover.JPG";
            string contentType = "application/JPG";
            string newFileName = "cover_.JPG";
            return File(filename, contentType, newFileName);
        }

        public ActionResult RoomDetails(Guid roomId)
        {
            var data = Response;
            var data2 = RouteData;
            var data3 = HttpContext;

            if(roomId == null || roomId == Guid.Empty)
                roomId = Guid.Parse(RouteData.Values["id"].ToString());

            return View(_serviceRoom.GetRoom(roomId));
        }   
        
        [HttpPost]
        public ActionResult CheckAvailability(Guid roomId, DateTime arrive, DateTime departure)
        {
            string availabilityRoom = "";
           
            TempData["CheckAvailabilityResult"] = _serviceRoom.CheckAvailability(roomId, arrive, departure, out availabilityRoom);
            TempData["AvailabilityRoom"] = availabilityRoom;

            return RedirectToAction("RoomDetails", new { roomId});
        }

        public ActionResult BookingRoom(Guid roomId, DateTime arrive, DateTime departure)
        {
            Availabilty availabilty = new Availabilty(arrive, departure, roomId);
            availabilty.RoomId = _serviceRoom.GetRoom(roomId).RoomId;

            _serviceRoom.BookingRoom(availabilty);

            return RedirectToAction("RoomDetails", new { roomId });
        }
    }
}
