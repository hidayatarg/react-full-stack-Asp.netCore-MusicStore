using Backend.DataAccess.Abstruct;
using Backend.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DataAccess.Concrete
{
    public class AuthRepository : IAuthRepository
    {
        // Communication with dataBase
        private DataContext _context;
        // Dependency Injection
        public AuthRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<User> Register(User user, string password)
        {
            // Salting & Hashing Password
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                // key can be also used
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public void DeleteUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserWithId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> Login(string userName, string password)
        {
            throw new NotImplementedException();
        }

       

        public Task<User> UpdatePassword(int id, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUserInformation(User user, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UserExits(string userName)
        {
            if (await _context.Users.AnyAsync(x => x.UserName == userName))
            {
                return true;
            }
            return false;
        }
    }
}
