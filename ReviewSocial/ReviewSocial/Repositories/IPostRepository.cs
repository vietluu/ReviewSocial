using ReviewSocial.Models;
using System.Collections.Generic;

namespace ReviewSocial.Repositories
{
    public interface IPostRepository
    {
        List<Post> GetAll();
        List<Post> GetAllByCategoryId(int categoryId);
        Post GetById(int id);
        Post Create(Post post);
        void Update(Post post);
        void Delete(Post post);
    }
}
