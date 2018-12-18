using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using KingPim.Domain.Entities;

namespace KingPim.Persistence
{
    public class UserSeed
    {
        private KingPimDbContext _context;

        public UserSeed(KingPimDbContext context)
        {
            _context = context;
        }
        public void AddUsers(User user, string password)
        {
            // Create Admin , Publisher, Editor Accounts

            password = "admin11";
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            

            var newUser = _context.Users.Add(new User {
                Username = "admin@kingpim.com",
                Email = "admin@kingpim.com",
                UserRoleId = 1,
                FirstName = "Adde",
                LastName = "Min"
            });
            _context.SaveChanges();
        }
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
