using Microsoft.EntityFrameworkCore;
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
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;
        public AnimalService(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public void Create(Animal animal)
        {
            _animalRepository.Create(animal);
        }

        public Animal Delete(int id)
        {
            return _animalRepository.Delete(id);   
        }

        public Animal Update(Animal animal)
        {
            return _animalRepository.Update(animal);
        }

        public IQueryable<Animal> GetAll()
        {
            return _animalRepository.GetAll();
        }

        public Animal Get(int id)
        {
            return _animalRepository.Get(id);
        }

        public IQueryable<Animal> GetTopThreeAnimals()
        {
            var animalList = _animalRepository.GetAll().Include(c => c.Comments);
            var TopThree = animalList.OrderByDescending(animal => animal.Comments.Count()).Take(3);
            return TopThree;
        }


    }
}
