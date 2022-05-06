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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly PetShopDataContext _context;
        public CategoryRepository(PetShopDataContext context)
        {
            _context = context;
        }

        public void Create(Category category)
        {
            _context.Add(category);
            _context.SaveChanges(); 
        }

        public void Delete(Category category)
        {
            _context.Remove(category);
            _context.SaveChanges();
        }

        public Category Get(int id)
        {
            return _context.Categories.First(Category => Category.CategoryId == id);
        }

        public IEnumerable<Category> GetAll()
        {
           List<Category> categoryList = new List<Category>();
            _context.Categories.ToList().ForEach(category=>categoryList.Add(category));
            return categoryList;
        }

        public bool Update(Category newCategory)
        {
            var isExist=_context.Categories.Any(category => category.CategoryId == newCategory.CategoryId);
            if (isExist)
            {
                _context.Categories.Update(newCategory);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

       
    }
}
