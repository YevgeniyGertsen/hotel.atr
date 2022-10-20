using System;
using System.Collections.Generic;

namespace Hotel.ATR.EF.BLL.Model
{
    public partial class RoomProperty
    {
        public int RoomPropertiesId { get; set; }
        public string NamePropery { get; set; } = null!;
        public string ValuePropery { get; set; } = null!;
        public int? RoomId { get; set; }

        public virtual Room Room { get; set; }
    }
}
