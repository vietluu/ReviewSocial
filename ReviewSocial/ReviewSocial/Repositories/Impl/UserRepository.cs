using ReviewSocial.Database;
using ReviewSocial.Models;
using System.Collections.Generic;
using System.Linq;

namespace ReviewSocial.Repositories.Impl
{
    public class UserRepository : IUserRepository
    {
        private readonly db_ReviewSocialContext _context;

        public UserRepository(db_ReviewSocialContext context)
        {
            _context = context;
        }

        public User Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public List<User> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email);
        }

        public User Update(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
