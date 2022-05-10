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

        public Comment Delete(int commentId)
        {
            var tmpComment = Get(commentId);
            if (tmpComment == null) return null;
            _context.Comments.Remove(tmpComment);
            _context.SaveChanges();
            return tmpComment;

        }
        public Comment Get(int id)
        {
            return _context.Comments.First(comment=>comment.CommentId==id);            
        }

        public IQueryable<Comment> GetAll()
        {
            return _context.Comments;     
        }
        public Comment Update(Comment newComment)
        {
             if (newComment == null) return null;
            _context.Comments.Update(newComment);
            _context.SaveChanges();
            return newComment;
        }
    }
}
