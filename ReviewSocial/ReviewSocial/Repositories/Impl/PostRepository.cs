using Microsoft.EntityFrameworkCore;
using ReviewSocial.Database;
using ReviewSocial.Models;
using System;
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

        // hàm sắp xếp
        public List<Post> GetAll(string sortBy)
        {
            var posts = _context.Posts.Include(p => p.Category).AsQueryable();

            #region Sorting
            // Default sort by Title (Tiêu đề)
            // posts = posts.OrderByDescending(hh => hh.Title);

            // Sắp xếp ngày tạo mới nhất lên đầu
            posts = posts.OrderByDescending(hh => hh.CreatedDate);

            // Sắp xếp ngày tạo cũ nhất lên đầu
            //posts = posts.OrderBy(hh => hh.CreatedDate);

            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "title_asc":
                        posts = posts.OrderBy(hh => hh.Title);
                        break;
                    case "title_desc":
                        posts = posts.OrderByDescending(hh => hh.Title);
                        break;
                    case "category_name_asc":
                        posts = posts.OrderBy(hh => hh.Category.Name);
                        break;
                    case "category_name_desc":
                        posts = posts.OrderByDescending(hh => hh.Category.Name);
                        break;
                }
            }
            #endregion

            return posts.ToList();
        }
        public List<Post> GetAllByCategoryId(int categoryId)
        {
            return _context.Posts.Include(p => p.Category).Include(p => p.User).Where(p => p.CategoryId == categoryId).ToList();
        }

        // hàm tìm kiếm post từ khóa nào đó
        public List<Post> Search(string keyword)
        {
            return _context.Posts.Include(p => p.Category).Where(p => p.Title.Contains(keyword) || p.Content.Contains(keyword)).ToList();
        }
        public Post GetPostAndUserAndCategoryById(int id)
        {
            return _context.Posts.Include(p=>p.User).Include(p=>p.Category).SingleOrDefault(p => p.Id == id);
        }

        public Post GetById(int id)
        {
            return _context.Posts.SingleOrDefault(p => p.Id == id);
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

        //hàm tìm kiếm trang chủ
        public List<Post> Search(string keyword, int? CategoryId, DateTime? from, DateTime? to)
        {
            var posts = _context.Posts.Include(p => p.Category).AsQueryable();

            #region Filtering
            if (!string.IsNullOrEmpty(keyword))
            {
                posts = posts.Where(p => p.Title.Contains(keyword) || p.Content.Contains(keyword));
            }
            if (CategoryId.HasValue)
            {
                posts = posts.Where(p => p.CategoryId == CategoryId);
            }
            if (from.HasValue)
            {
                posts = posts.Where(hh => hh.CreatedDate >= from);
            }
            if (to.HasValue)
            {
                posts = posts.Where(hh => hh.CreatedDate <= to);
            }
            if (from.HasValue && to.HasValue)
            {
                posts = posts.Where(p => p.CreatedDate >= from && p.CreatedDate <= to);
            }
            #endregion

            return posts.ToList();
        }

        public bool CheckExitsTitle(string title)
        {
            return _context.Posts.Any(p => p.Title == title);
        }
    }
}
