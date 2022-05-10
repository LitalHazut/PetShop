using PetShop.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Data.Repositories.Interfaces
{
    public interface IRepository<T> where T: class
    {
        T Get(int id);
        IQueryable<T> GetAll();
        T Delete(int id);
        T Update(T entity);
        void Create(T entity);
    }
  

    
}
