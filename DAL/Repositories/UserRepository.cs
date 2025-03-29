using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository
    {
        private readonly SkincareShopContext _context;

        public UserRepository()
        {
            _context = new SkincareShopContext();
        }

        public User? GetUser(string email, string password)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email && x.PasswordHash == password);
        }
    }
}
