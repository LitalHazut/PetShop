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
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public void Create(Comment comment)
        {
            _commentRepository.Create(comment);
        }

        public Comment Delete(int commentId)
        {
            return _commentRepository.Delete(commentId);
        }
        
        public Comment Get(int id)
        {
           return _commentRepository.Get(id);   
        }

        public IQueryable<Comment> GetAll()
        {
            return _commentRepository.GetAll();
        }

        public IQueryable<Comment> GetByAnimalId(int id)
        {
            return _commentRepository.GetAll()
                .Where(c => c.AnimalId == id);
        }

        public Comment Update(Comment comment)
        {
            return _commentRepository.Update(comment);
        }
    }
}
