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
        public async Task<User> Login(string userName, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
            if (user == null)
            {
                return null;
            }
            // Check if the password match
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }
            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] userPasswordHash, byte[] userPasswordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(userPasswordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                //compare
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != userPasswordHash[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public void DeleteUserById(int id)
        {
            var userInDb = _context.Users.FirstOrDefault(c => c.Id == id);
            if (userInDb == null)
            {
                throw new InvalidOperationException();
            }
            _context.Users.Remove(userInDb);
            _context.SaveChanges();
        }

        public async Task<User> GetUserWithId(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<User> UpdatePassword(int id, string oldPassword, string newPassword)
        {
            var userInDb = await _context.Users.FirstOrDefaultAsync(c => c.Id == id);
            if (userInDb == null)
                return null;
            //check the user old password
            if (!VerifyPasswordHash(oldPassword, userInDb.PasswordHash, userInDb.PasswordSalt))
                return null;

            // Update Process
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(newPassword, out passwordHash, out passwordSalt);

            userInDb.PasswordHash = passwordHash;
            userInDb.PasswordSalt = passwordSalt;

            _context.Users.Update(userInDb);
            await _context.SaveChangesAsync();
            return userInDb;
        }

        public async Task<User> UpdateUserInformation(User user, string password)
        {
            //var user = _context.Users.Where(c => c.Id == id).FirstOrDefault();
            //var userInDb = _context.Users.FirstOrDefault(c => c.Id == id);

            var userInDb = await _context.Users.FirstOrDefaultAsync(c => c.Id == user.Id);
            // If user with entered id is not in db
            if (userInDb == null)
            {
                return null;
            }
            // Update the password if the user has entered an new password
            byte[] passwordHash, passwordSalt;
            if (password != null)
            {
                CreatePasswordHash(password, out passwordHash, out passwordSalt);
                userInDb.PasswordHash = passwordHash;
                userInDb.PasswordSalt = passwordSalt;
            }
            _context.Users.Update(userInDb);
            _context.SaveChanges();
            return userInDb;

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
