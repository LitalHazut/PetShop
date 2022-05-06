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
    public class CommentService:ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public bool CreateNewByAnimalId(string comment, int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteByAnimalId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetByAnimalId(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateById(int id, string comment)
        {
            throw new NotImplementedException();
        }
    }
}
