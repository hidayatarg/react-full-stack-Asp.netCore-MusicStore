﻿using Backend.DataAccess.Abstruct;
using Backend.Entities;
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
            // Salting Password
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordHash = passwordSalt;
            await _context.Users.AddAsync(user);

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

        public Task<bool> UserExits(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
