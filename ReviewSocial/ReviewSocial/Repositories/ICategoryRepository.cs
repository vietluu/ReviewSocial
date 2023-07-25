using ReviewSocial.Models;
using System.Collections.Generic;

namespace ReviewSocial.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Category GetById(int id);
        List<Category> Search(string keyword);
        Category GetByName(string name);
        bool ExistsByName (string name);
        Category Create(Category category);
        void Update(Category category);
        void Delete(Category category);

        // hàm để sắp xếp
        List<Category> GetAll(string sortBy);
    }
}
