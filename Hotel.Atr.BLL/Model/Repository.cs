using Dapper;
using Hotel.Atr.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Atr.BLL.Model
{
    public class Repository<T> : IRepository<T>
    {
        public string connectionString
        {
            get
            {
                return @"Server=223-17\MSSQLSERVER99;Database=ATR;Trusted_Connection=True;";
            }
        }

        public void Create(T obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(T obj)
        {
            throw new NotImplementedException();
        }

        public List<T> Get()
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                db.Open();

                List<T> data = db.Query<T>("SELECT * FROM " + typeof(T).Name).ToList();

                return data;
            }
        }

        public T GetItemById(int id)
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                db.Open();

                string query = "SELECT * FROM " + typeof(T).Name +
                    " WHERE " + typeof(T).Name + "Id = @Id";


                T data = db.QueryFirstOrDefault<T>(query, new { Id = id });

                return data;
            }
        }

        public void Update(T obj)
        {
            //
        }
    }
}
