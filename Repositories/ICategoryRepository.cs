using ReviewSocial.Models;
using System.Collections.Generic;

namespace ReviewSocial.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Category GetById(int id);
        Category GetByName(string name);
        bool ExistsByName(string name);
        Category Create(Category category);
        void Update(Category category);
        void Delete(Category category);
    }
}
