using PetShop.Data.Model;
using PetShop.Data.Repositories.Interfaces;
using PetShop.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Service
{
    public class AnimalService:IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;
        public AnimalService(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public bool Create(Animal animal)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            _animalRepository.Delete(GetById(id));
            return true;
        }

        public bool EditDetalis(Animal animal)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Animal> GetAll()
        {
            throw new NotImplementedException();
        }

        public Animal GetById(int id)
        {
            return _animalRepository.Get(id);
        }

        public IEnumerable<Animal> SerachByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
