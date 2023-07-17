using ReviewSocial.Models;
using System.Collections.Generic;

namespace ReviewSocial.Repositories
{
    public interface IUserRepository
    {
        public List<User> GetAll();
        public User Create(User user);
        public User Update(User user);
        public User GetUserByEmail(string email);
    }
}
