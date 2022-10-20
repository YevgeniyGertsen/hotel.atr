using Hotel.ATR.EF.BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ATR.EF.BLL.Interfaces
{
    public interface ILocationService
    {
        List<Location> GetLocations();
        Location GetLocation(int id);
        void UpdateViewsLocation(int id);
    }
}
