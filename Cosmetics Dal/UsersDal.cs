using Cosmetics_Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmetics_Dal
{
    public class UsersDal : IUsersDal
    {
        private readonly SHOPContext db;

        public UsersDal(SHOPContext db)
        {
            this.db = db;
        }

        public void AddUsers(Users user)
        {
            var isExist = db.Users.Any(x => x.Username == user.Username);

            if (!isExist)
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
            else
            {
                throw new Exception("Username already exists.");
            }
        }

        public void DeleteUser(int userId)
        {
            var user = db.Users.Find(userId);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"User with ID {userId} could not be found to delete.");
            }
        }

        public List<Users> GetAllUsers()
        {
            return db.Users.ToList();
        }

        public Users GetUsersById(int id)
        {
            return db.Users.Find(id);
        }

        // "Code" here refers to the user's identifying number (UserId)
        public Users GetUserByCode(int userCode)
        {
            return db.Users.Find(userCode);
        }

        public Users GetUserByUsernameAndPassword(string username, string password)
        {
            return db.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public void UpdateUsers(Users user)
        {
            var existingUser = db.Users.Find(user.UserId);

            if (existingUser != null)
            {
                // Update every editable field, not just Username
                existingUser.Username = user.Username;
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Phone = user.Phone;
                existingUser.Address = user.Address;
                existingUser.Email = user.Email;

                // Only overwrite the password if the caller actually supplied a new one
                if (!string.IsNullOrEmpty(user.Password))
                {
                    existingUser.Password = user.Password;
                }

                db.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"User with ID {user.UserId} could not be found to update.");
            }
        }
    }
}
