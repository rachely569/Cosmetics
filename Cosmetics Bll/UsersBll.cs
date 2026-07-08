using Cosmetics_Dal;
using Cosmetics_Dal.Models;
using System.Collections.Generic;

namespace Cosmetics_Bll
{
    public class UsersBll : IUsersBll
    {
        private readonly IUsersDal _usersDal;

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

        public Users GetUserByCode(int userCode)
        {
            return _usersDal.GetUserByCode(userCode);
        }

        public Users GetUserByUsernameAndPassword(string username, string password)
        {
            return _usersDal.GetUserByUsernameAndPassword(username, password);
        }

        public void UpdateUsers(Users user)
        {
            _usersDal.UpdateUsers(user);
        }
    }
}
