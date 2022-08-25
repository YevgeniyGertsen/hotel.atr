using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Atr.BLL.Model
{
    public class ServiceRoom
    {
        string connectionString = @"Server=223-17\MSSQLSERVER99;Database=ATR;Trusted_Connection=True;";
        public List<Room> GetRooms()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                }
            }
            catch (Exception ex)
            {
                string exeption = ex.Message;
            }
            
            return new List<Room>();
        }
    }
}
