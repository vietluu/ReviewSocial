using Microsoft.EntityFrameworkCore;
using ReviewSocial.Database;
using ReviewSocial.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;


namespace ReviewSocial.Repositories.Impl
{
    public class CommentRepository : ICommentRepository
    {
        private readonly Db_ReviewSocialContext _context;

        public CommentRepository(Db_ReviewSocialContext context)

        {
            _context = context;
        }


        public Comment Create(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return comment;
        }

        public Comment GetById(int id)
        {
            return _context.Comments.Find(id);
        }
        public int CountByPost(int id)
        {
            return _context.Comments.Where(p => p.PostsId == id).Count();

        }

        public IEnumerable<Comment> GetByPost(int id)
        {
            return _context.Comments.Where(p => p.PostsId == id).Include(p => p.Posts).Include(p => p.User).ToList();
        }

        public void Update(Comment comment)
        {
            _context.Comments.Update(comment);
            _context.SaveChanges();
        }

        public void Delete(Comment comment)
        {
            if (comment != null)
            {
                _context.Comments.Remove(comment);
                _context.SaveChanges();
            }

        }

    }
}
