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
            _context.Categories.Add(category);
            _context.SaveChanges(); 
        }

        public Category Delete(int categoryId)
        {
            var tmpCategory = Get(categoryId);
            if (tmpCategory == null) return null;
            _context.Categories.Remove(tmpCategory);
            _context.SaveChanges();
            return tmpCategory;
        }

        public Category Get(int id)
        {
            return _context.Categories.First(Category => Category.CategoryId == id);
            
        }

        public IQueryable<Category> GetAll()
        {
            return _context.Categories.AsQueryable();

        }

        public Category Update(Category newCategory)
        {
            if (newCategory == null) return null;
            _context.Categories.Update(newCategory);
            _context.SaveChanges();
            return newCategory; ;
        }

       
    }
}
