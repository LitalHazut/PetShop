using PetShop.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Service.Interfaces
{
    public interface ICommentService:ICRUDService<Comment>
    {
        IEnumerable<Comment> GetByAnimalId(int id);
        
        

    }
}
