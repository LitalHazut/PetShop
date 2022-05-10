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
    public class BusinessLogic : IBusinessLogic
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly ICategoryRepository _categoryRepository;
        public BusinessLogic(IAnimalRepository animalRepository, ICommentRepository commentRepository, ICategoryRepository categoryRepository)
        {
            _animalRepository = animalRepository;
            _commentRepository = commentRepository;
            _categoryRepository = categoryRepository;
        }

        public void DeleteAnimal(Animal animal)
        {
            int animalId = animal.AnimalId;
            _commentRepository.GetAll().Where(comment => comment.AnimalId == animalId)
            .ToList().ForEach(comment => _commentRepository.Delete(comment.CommentId));

            _animalRepository.Delete(animal.AnimalId);
        }

        public IEnumerable<Animal> GetAnimalsByCategory(Category category)
        {
            int categoryId = category.CategoryId;
            List<Animal> animalList = new List<Animal>();
            _animalRepository.GetAll()
                .Where(animal => animal.CategoryId == categoryId)
                .ToList()
                .ForEach(animal => animalList.Add(animal));
            return animalList;
        }

        public IEnumerable<Animal> GetTopThreeAnimals()
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<Animal> GetTopThreeAnimals()
        //{
        //    List<int> idList = new List<int>();
        //    _commentRepository
        //   .GetAll()
        //   .GroupBy(comment => comment.AnimalId)
        //   .Select(group => new { commentsGroup = group, totalComments = group.Count() })
        //   .Take(3)
        //   .OrderByDescending(row => row.totalComments)
        //   .ToList()
        //   .ForEach(row => idList.Add(row.commentsGroup.Key));

        //    List<Animal> animalList = new List<Animal>();
        //    _animalRepository
        //    .GetAll()
        //    .Where(animal => idList.Contains(animal.AnimalId))
        //    .ToList()
        //    .ForEach(animal => animalList.Add(animal));

        //    return animalList;
        //}
    }
}
