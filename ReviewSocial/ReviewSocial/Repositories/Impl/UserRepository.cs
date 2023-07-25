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

        public void Delete(User user)
        {
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public List<User> GetAll()
        {
            return _context.Users.Where(u=>u.Status ==true).ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.SingleOrDefault(u=>u.Id == id);
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email);
        }

        public User GetUserByEmailAndPassword(string email, string password)
        {
            return _context.Users.SingleOrDefault(u =>u.Email == email && u.Password == password);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}
