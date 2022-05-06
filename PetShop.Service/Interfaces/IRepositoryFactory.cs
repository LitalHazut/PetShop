using PetShop.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Service.Interfaces
{
    public interface IRepositoryFactory
    {
        IAnimalRepository CreateAnimalRepo();
        ICommentRepository CreateCommentRepo();
        ICategoryRepository CreateCategoryRepo();


    }
}
