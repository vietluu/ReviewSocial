using ReviewSocial.Models;
using System.Collections.Generic;

namespace ReviewSocial.Repositories
{
    public interface IUserRepository
    {
        public List<User> GetAll();
        public User GetById(int id);

        public User Create(User user);
        void Update(User user);
        void Delete(User user);
        public User GetUserByEmail(string email);
        public User GetUserByEmailAndPassword(string email,string password);
    }
}
