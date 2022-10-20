using Hotel.ATR.EF.BLL.Data;
using Hotel.ATR.EF.BLL.Interfaces;
using Hotel.ATR.EF.BLL.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ATR.EF.BLL
{
    public class LocationService : ILocationService
    {
        private readonly HotelAtrDbContext db;

        public LocationService(HotelAtrDbContext _db)
        {
            db = _db;
        }

        public List<Location> GetLocations()
        {
            return db.Locations.ToList();
        }

        public Location GetLocation(int id)
        {
            Location data = db.Locations
                .FirstOrDefault(f => f.LocationId.Equals(id));

            return data;
        }

        public void UpdateViewsLocation(int id)
        {
            var data = db.Locations.Find(id);
            data.Views = data.Views + 1;
            db.SaveChanges();
        }
    }
}