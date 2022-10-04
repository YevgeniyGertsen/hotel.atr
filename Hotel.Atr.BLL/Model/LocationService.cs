using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Hotel.Atr.BLL.Model
{
    public class LocationService
    {
        string connectionString = @"Server=223-17\MSSQLSERVER99;Database=ATR;Trusted_Connection=True;";

        public List<Location> GetLocations()
        {
            try
            {
                using (SqlConnection db = new SqlConnection(connectionString))
                {
                    db.Open();

                    List<Location> data = db.Query<Location>
                        ("SELECT * FROM Location ")
                        .ToList();

                    return data;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Location GetLocation(int id)
        {
            try
            {
                Location data = GetLocations().FirstOrDefault(f => f.LocationId.Equals(id));

                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void UpdateViewsLocation(int id)
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                db.Open();

                db.Execute("update Location set Views = Views+1 where LocationId = @LocationId",
                    new { LocationId = id });

            }
        }
    }
}
