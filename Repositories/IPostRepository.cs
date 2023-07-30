using ReviewSocial.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;



namespace ReviewSocial.Repositories
{
    public interface IPostRepository
    {
        List<Post> GetAll();
        Post GetById(int id);
        IEnumerable<Post> GetByTitle(string name);
        bool ExistsByTitle(string name);
        public IEnumerable<Post> GetByCategory(int id);
        public IEnumerable<Post> GetByUser(int id);


        Post Create(Post post);
        void Update(Post post);
        void Delete(Post post);
        Task<string> UploadFile(IFormFile file);

    }
}
