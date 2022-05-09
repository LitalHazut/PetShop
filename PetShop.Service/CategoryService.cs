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
    public class CategoryService:ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Create(Category category)
        {
          _categoryRepository.Create(category);
        }

        public void Delete(Category category)
        {
            _categoryRepository.Delete(category);
        }

        public Category Get(int id)
        {
            return _categoryRepository.Get(id);
        }

        public IEnumerable<Category> GetAll()
        {
           return _categoryRepository.GetAll();
                            
        }

        public bool Update(Category category)
        {
           return _categoryRepository.Update(category);   
        }
    }
}
