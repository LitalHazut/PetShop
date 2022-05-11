using Microsoft.EntityFrameworkCore;
using PetShop.Data.Contexts;
using PetShop.Data.Model;
using PetShop.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Data.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly PetShopDataContext _context;
        public AnimalRepository(PetShopDataContext context)
        {
            _context = context;
        }

        public void Create(Animal animal)
        {
            _context.Animals.Add(animal);
            _context.SaveChanges();

        }

        public Animal Delete(int animalId)
        {
            var tmpAnimal = Get(animalId);
            if (tmpAnimal == null) return null ;
            _context.Animals.Remove(tmpAnimal);
            _context.SaveChanges();
            return tmpAnimal;
        }

        public Animal Get(int id)
        {

            var tmpAnimal = _context.Animals.FirstOrDefault(a => a.AnimalId == id);
            if (tmpAnimal == null) return null;
            return tmpAnimal;

        }

        public IQueryable<Animal> GetAll()
        {
            return _context.Animals;
        }

        public Animal Update(Animal newAnimal)
        {
            if (newAnimal == null) return null;
            _context.Animals.Update(newAnimal);
            _context.SaveChanges();
            return newAnimal;
        }

    }
}
