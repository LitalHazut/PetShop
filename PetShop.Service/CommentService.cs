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

        public void Create(Comment entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Comment entity)
        {
            throw new NotImplementedException();
        }

        public Comment Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetByAnimalId(int id)
        {
            return _commentRepository.GetAll()
                .Where(c => c.AnimalId == id);    
        }

        public bool Update(Comment entity)
        {
            throw new NotImplementedException();
        }
    }
}
