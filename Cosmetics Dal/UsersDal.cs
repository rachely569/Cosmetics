using Cosmetics_Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics_Dal
{
    public class UsersDal : IUsersDal
    {
        SHOPContext db;

        public UsersDal(SHOPContext db)
        {
            this.db = db;
        }
        public void AddUsers(Users user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            var user = db.Users.ToList().Find(x => x.UserId == userId);
            db.Users.Remove(user);
            db.SaveChanges();
        }

        public List<Users> GetAllUsers()
        {
            return db.Users.ToList();
        }

        public Users GetUsersById(int id)
        {
            return db.Users.ToList().Find(x => x.UserId == id);
        }

        public void UpdateUsers(Users user)
        {
            var users = db.Users.ToList().Find(x => x.UserId == user.UserId);
            users.Username = user.Username;
            db.SaveChanges();
        }
    }
}
