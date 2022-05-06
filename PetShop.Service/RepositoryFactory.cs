using PetShop.Data.Contexts;
using PetShop.Data.Repositories;
using PetShop.Data.Repositories.Interfaces;
using PetShop.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Service
{
    public class RepositoryFactory : IRepositoryFactory
    {
        public IAnimalRepository CreateAnimalRepo()
        {
            AnimalRepository animalRepo = new(new PetShopDataContext());
            return animalRepo;
        }

        public ICategoryRepository CreateCategoryRepository()
        {
            CategoryRepository categoryRepo = new(new PetShopDataContext());
            return categoryRepo;
        }

        public ICommentRepository CreateCommentRepo()
        {
           CommentRepository commentRepo = new(new PetShopDataContext());   
            return commentRepo;
        }
    }
}
