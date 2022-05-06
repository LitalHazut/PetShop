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
    public class CommentRepository : ICommentRepository
    {
        private readonly PetShopDataContext _context;
        public CommentRepository(PetShopDataContext context)
        {
            _context = context;
        }

        public void Create(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public void Delete(Comment comment)
        {
            _context.Comments.Remove(comment);
            _context.SaveChanges();
           
        }

        public Comment Get(int id)
        {
            return _context.Comments.First(comment=>comment.CommentId==id);            
            
                
        }

        public IEnumerable<Comment> GetAll()
        {
            List<Comment> commentList=new List<Comment>();
            _context.Comments.ToList().ForEach(comment =>commentList.Add(comment));
            return commentList;
                    
        }
        public bool Update(Comment newComment)
        {
            var isExist = _context.Comments.Any(comment => comment.CommentId == newComment.CommentId);
            if (isExist)
            {
                _context.Comments.Update(newComment);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
