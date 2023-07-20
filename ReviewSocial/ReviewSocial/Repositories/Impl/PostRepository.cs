using Microsoft.EntityFrameworkCore;
using ReviewSocial.Database;
using ReviewSocial.Models;
using System.Collections.Generic;
using System.Linq;

namespace ReviewSocial.Repositories.Impl
{
    public class PostRepository : IPostRepository
    {
        private readonly db_ReviewSocialContext _context;

        public PostRepository(db_ReviewSocialContext context)

        {
            _context = context;
        }
        public List<Post> GetAll()
        {
            return _context.Posts.Include(p => p.Category).Include(p => p.User).ToList();
        }

        public List<Post> GetAllByCategoryId(int categoryId)
        {
            return _context.Posts.Include(p => p.Category).Include(p => p.User).Where(p => p.CategoryId == categoryId).ToList();
        }

        public Post GetById(int id)
        {
            return _context.Posts.Include(p=>p.User).Include(p=>p.Category).SingleOrDefault(p => p.Id == id);
        }
        public Post Create(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
            post.User = _context.Users.SingleOrDefault(u => u.Id == post.UserId);
            return post;
        }

        public void Delete(Post post)
        {
            _context.Posts.Remove(post);
            _context.SaveChanges();
        }


        public void Update(Post post)
        {
            _context.Posts.Update(post);
            _context.SaveChanges();
        }
    }
}
