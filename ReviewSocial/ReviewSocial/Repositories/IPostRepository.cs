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
        Post GetByTitle(string name);
        bool ExistsByTitle (string name);
        Post Create(Post post);
        void Update(Post post);
        void Delete(Post category);
        Task<string> UploadFile(IFormFile file);

    }
}
