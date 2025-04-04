using DAL.Entities;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService
    {
        private UserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public User? GetUser(string email, string password)
        {
            return _userRepository.GetUser(email, password);
        }

        public User RegisterUser(string fullName, string email, string password, string role = "Customer")
        {
            if(_userRepository.IsEmailExist(email))
            {
                return null;
            }
            var newUser = new User
            {
                FullName = fullName,
                Email = email,
                PasswordHash = password,
                Role = role,
                CreatedAt = DateTime.Now
            };
            return _userRepository.CreateUser(newUser);
        }
        public User GetUserById(int userId)
        {
            return _userRepository.GetUserById(userId);
        }
       
        public bool UpdateUser(User user)
        {
            return _userRepository.UpdateUser(user);
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public bool DeleteUser(int userId)
        {
            return _userRepository.DeleteUser(userId);
        }
    }
}
