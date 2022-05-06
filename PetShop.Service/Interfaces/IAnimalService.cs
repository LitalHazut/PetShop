using PetShop.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Service.Interfaces
{
    public interface IAnimalService
    {
        Animal GetById(int id);
        IEnumerable<Animal> SerachByName(string name);
        bool Create(Animal animal);
        bool DeleteById(int id);
        bool EditDetalis(Animal animal);
        IEnumerable<Animal> GetAll();

        

    }
}
