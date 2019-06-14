using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DataAccess.Abstruct
{
    public interface IAuthRepository
    {
        // Register
        Task<User> Register(User user, string password);
        // Login
        Task<User> Login(string userName, string password);
        // Find if User exists
        Task<bool> UserExits(string userName);
        // Get User Information
        Task<User> GetUserWithId(int id);
        // Update User Password
        Task<User> UpdatePassword(int id, string oldPassword, string newPassword);
        // Update User Information
        Task<User> UpdateUserInformation(User user, string password);
        // Delete User
        void DeleteUserById(int id);
    }
}
