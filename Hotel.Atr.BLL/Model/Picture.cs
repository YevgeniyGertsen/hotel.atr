using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Atr.BLL.Model
{
    public class Picture
    {
        public int PictureId { get; set; }
        public int RoomId { get; set; }
        public string Name { get; set; }
        public string UrlPicture { get; set; }
        public bool MainPicture { get; set; }
        public Room Room { get; set; }

        public Picture(string url)
        {
            UrlPicture = url;
        }
        public Picture() { }
    }
}
