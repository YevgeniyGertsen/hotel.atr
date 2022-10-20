using System;
using System.Collections.Generic;

namespace Hotel.ATR.EF.BLL.Model
{
    public partial class Picture
    {
        public Picture() { }
        public Picture(string url)
        {
            UrlPicture = url;
        }       

        public int PictureId { get; set; }
        public int RoomId { get; set; }
        public string Name { get; set; } = null!;
        public string UrlPicture { get; set; }
        public bool MainPicture { get; set; }

        public virtual Room Room { get; set; }
    }
}
