using ReviewSocial.Models;
using System;
using System.Collections.Generic;

namespace ReviewSocial.Repositories
{
    public interface IPostRepository
    {
        List<Post> GetAll();
        List<Post> GetAll(string sortBy);
        List<Post> GetAllByCategoryId(int categoryId);
        List<Post> Search(string keyword);
        Post GetPostAndUserAndCategoryById(int id);
        Post GetById(int id);
        Post Create(Post post);
        void Update(Post post);
        void Delete(Post post);
        List<Post> Search(string keyword, int? subCategoryId, DateTime? from, DateTime? to);
        bool CheckExitsTitle(string title);
    }
}
