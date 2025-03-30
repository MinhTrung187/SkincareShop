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

        public bool IsEmailExist(string email)
        {
            return _context.Users.Any(x => x.Email == email);
        }

        public User CreateUser(User obj)
        {
            using (var db = new SkincareShopContext())
            {
                try
                {
                    db.Users.Add(obj);
                    db.SaveChanges();
                    return obj;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi tạo user: " + ex.Message);
                    return null;
                }
            }
        }

    }
}
