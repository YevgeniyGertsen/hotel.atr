using Hotel.Atr.BLL.Model;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Text;

namespace Hotel.Atr.Controllers
{
    public class RoomController : Controller
    {
        private ServiceRoom serviceRooms = new ServiceRoom();

        // GET: RoomController
        public ActionResult Index()
        {
            ViewBag.Description = "List Room";
            ViewBag.Title = "Room";

            return View(serviceRooms.GetRooms());
        }
        


        public ActionResult RoomList()
        {
            return View(serviceRooms.GetRooms());
        }

        public JsonResult RoomListjSON()
        {
            var data = serviceRooms.GetRooms();
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

        public ActionResult RoomDetails( string availabilityRoom="")
        {
            var data = Response;
            var data2 = RouteData;
            var data3 = HttpContext;

            Guid roomId = Guid.Parse(RouteData.Values["id"].ToString());
            return View(serviceRooms.GetRoom(roomId));
        }   
        
        [HttpPost]
        public ActionResult CheckAvailability(Guid roomId, DateTime arrive, DateTime departure)
        {
            string availabilityRoom = "";
           
            TempData["CheckAvailabilityResult"] = serviceRooms.CheckAvailability(roomId, arrive, departure, out availabilityRoom);
            TempData["AvailabilityRoom"] = availabilityRoom;

            return RedirectToAction("RoomDetails", new { roomId, availabilityRoom });
        }

        public ActionResult BookingRoom(Guid roomId, DateTime arrive, DateTime departure)
        {
            Availabilty availabilty = new Availabilty(arrive, departure, roomId);

            serviceRooms.BookingRoom(availabilty);

            return View();
        }

        //public string SomeMethod()
        //{
        //    return "<h1>Test</h1>";
        //}

        //[NonAction]
        //public string SomeMethod2()
        //{
        //    return Content("<h1>Test</h1>").ToString();
        //}
    }
}
