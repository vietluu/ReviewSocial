using Microsoft.EntityFrameworkCore;
using ReviewSocial.Database;
using ReviewSocial.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using System;

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
            return _context.Posts.Include(c => c.User).Include(p => p.Comments).Include(p => p.Category).ToList();
        }
        public Post Create(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
            return post;
        }
        public IEnumerable<Post> GetByUser(int id)
        {

            return _context.Posts.Where(p => p.UserId == id).Include(p => p.Category).Include(p => p.User).Include(p => p.Comments).ToList();

        }
        public Post GetById(int id)
        {
            return _context.Posts.Include(p => p.User).SingleOrDefault(p => p.Id == id);
        }
        public IEnumerable<Post> GetByCategory(int id)
        {
            return _context.Posts.Where(p => p.CategoryId == id).Include(p => p.Category).Include(p => p.User).ToList();
        }
        public IEnumerable<Post> GetByTitle(string title)
        {
            return _context.Posts.Where(p => p.Title.Contains(title)).Include(p => p.User).Include(p => p.Comments).ToList();
        }
        public bool ExistsByTitle(string title)
        {
            return _context.Posts.Any(c => c.Title == title);
        }
        public void Update(Post post)
        {
            _context.Posts.Update(post);
            _context.SaveChanges();
        }

        public void Delete(Post post)
        {
            if (post != null)
            {
                _context.Posts.Remove(post);
                _context.SaveChanges();
            }

        }
        public async Task<string> UploadFile(IFormFile file)
        {

            if (file != null)
            {
                
                var fileName = DateTime.UtcNow.Ticks.ToString() + Path.GetExtension(Path.GetFileName(file.FileName));
                var filePath = Path.Combine("wwwroot", "img", fileName);
                if (!File.Exists(filePath))
                {
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
                return $"img/{fileName}";
            }
            else
            {
                return "";
            }
        }
    }
}
