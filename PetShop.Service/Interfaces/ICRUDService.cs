using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Service.Interfaces
{
    public interface ICRUDService<T> where T : class
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        void Delete(T entity);
        bool Update(T entity);
        void Create(T entity);


    }
}
