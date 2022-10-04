using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Atr.BLL.Interfaces
{
    public interface IRepository<T>
    {
        string connectionString { get; }
             
        List<T> Get();

        void Create(T obj);

        void Update(T obj);

        void Delete(T obj);

        T GetItemById(int id);
    }
}
