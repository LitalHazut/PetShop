﻿using PetShop.Data.Model;
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

        public void Delete(Animal animal)
        {
            _animalRepository.Delete(animal);

        }

        public bool Update(Animal animal)
        {
            return _animalRepository.Update(animal);
        }

        public IEnumerable<Animal> GetAll()
        {
            return _animalRepository.GetAll();
        }

        public Animal Get(int id)
        {
            return _animalRepository.Get(id);
        }

        public IEnumerable<Animal> SerachByName(string name)
        {
            return _animalRepository.GetAll().
                Where(animal => animal.Name.ToLower().Contains(name.ToLower()));
        }


    }
}
