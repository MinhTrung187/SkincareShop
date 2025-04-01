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

        public bool UpdateUser(User user)
        {
            using (var db = new SkincareShopContext())
            {
                try
                {
                    var existingUser = db.Users.FirstOrDefault(u => u.UserId == user.UserId);
                    if (existingUser != null)
                    {
                        existingUser.FullName = user.FullName;
                        existingUser.PasswordHash = user.PasswordHash;
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi cập nhật user: " + ex.Message);
                    return false;
                }
            }
        }

        public List<User> GetAllUsers()
        {
            using (var db = new SkincareShopContext())
            {
                return db.Users.ToList();
            }
        }

        public bool DeleteUser(int userId)
        {
            using (var db = new SkincareShopContext())
            {
                var user = db.Users.FirstOrDefault(x => x.UserId == userId);
                if (user == null)
                    return false;

                try
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi xóa user: " + ex.Message);
                    return false;
                }
            }
        }

    }
}
