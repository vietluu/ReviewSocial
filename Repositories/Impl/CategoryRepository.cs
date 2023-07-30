using Microsoft.EntityFrameworkCore;
using ReviewSocial.Database;
using ReviewSocial.Models;
using System.Collections.Generic;
using System.Linq;

namespace ReviewSocial.Repositories.Impl
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Db_ReviewSocialContext _context;

        public CategoryRepository(Db_ReviewSocialContext context)

        {
            _context = context;
        }

        public List<Category> GetAll()
        {
            return _context.Categories.Include(c => c.Posts).ToList();
        }
        public Category Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }

        public Category GetById(int id)
        {
            return _context.Categories.SingleOrDefault(c => c.Id == id);
        }
        public Category GetByName(string name)
        {
            return _context.Categories.SingleOrDefault(c => c.Name == name);
        }
        public bool ExistsByName(string name)
        {
            return _context.Categories.Any(c => c.Name == name);
        }
        public void Update(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public void Delete(Category category)
        {
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }

        }
    }
}
