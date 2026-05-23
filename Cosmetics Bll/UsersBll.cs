using Cosmetics_Dal;
using Cosmetics_Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics_Bll
{
    public class UsersBll : IUsersBll
    {
        // Changed type to use the interface
        private readonly IUsersDal _usersDal;

        // The constructor now correctly requests the interface registered in Program.cs
        public UsersBll(IUsersDal usersDal)
        {
            _usersDal = usersDal;
        }

        public void AddUsers(Users user)
        {
            _usersDal.AddUsers(user);
        }

        public void DeleteUser(int userId)
        {
            _usersDal.DeleteUser(userId);
        }

        public List<Users> GetAllUsers()
        {
            return _usersDal.GetAllUsers();
        }

        public Users GetUsersById(int id)
        {
            return _usersDal.GetUsersById(id);
        }

        public void UpdateUsers(Users user)
        {
            _usersDal.UpdateUsers(user);
        }
    }
}