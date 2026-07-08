using Cosmetics_Dal.Models;
using System.Collections.Generic;

namespace Cosmetics_Dal
{
    public interface IUsersDal
    {
        List<Users> GetAllUsers();

        Users GetUsersById(int id);

        Users GetUserByCode(int userCode);

        Users GetUserByUsernameAndPassword(string username, string password);

        void AddUsers(Users user);

        void DeleteUser(int userId);

        void UpdateUsers(Users user);
    }
}
