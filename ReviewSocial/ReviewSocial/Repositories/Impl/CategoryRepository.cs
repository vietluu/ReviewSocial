using Microsoft.EntityFrameworkCore;
using ReviewSocial.Database;
using ReviewSocial.Models;
using System.Collections.Generic;
using System.Linq;

namespace ReviewSocial.Repositories.Impl
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly db_ReviewSocialContext _context;
        
        public CategoryRepository(db_ReviewSocialContext context)

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
            return _context.Categories.Include(c => c.Posts).SingleOrDefault(c => c.Id == id);
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

        // hàm tìm kiếm category bên ad
        // hàm tìm kiếm post từ khóa nào đó
        public List<Category> Search(string keyword)
        {
            return _context.Categories.Where(c => c.Name.Contains(keyword)).ToList();
        }


        // hàm sắp xếp
        public List<Category> GetAll(string sortBy)
        {
            var categories = _context.Categories.AsQueryable();

            #region Sorting
            // Default sort by Title (Tiêu đề)
            categories = categories.OrderByDescending(hh => hh.Name);

            // Sắp xếp ngày tạo mới nhất lên đầu
            //posts = posts.OrderByDescending(hh => hh.CreatedDate);

            // Sắp xếp ngày tạo cũ nhất lên đầu
            //posts = posts.OrderBy(hh => hh.CreatedDate);

            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "category_name_asc":
                        categories = categories.OrderBy(hh => hh.Name);
                        break;
                    case "category_name_desc":
                        categories = categories.OrderByDescending(hh => hh.Name);
                        break;
                }
            }
            #endregion

            return categories.ToList();
        }
    }
}
