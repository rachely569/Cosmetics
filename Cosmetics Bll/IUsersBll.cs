using Cosmetics_Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics_Bll
{
    public interface IUsersBll
    {
        List<Users> GetAllUsers();

        Users GetUsersById(int id);

        void AddUsers(Users user);

        void DeleteUser(int userId);

        void UpdateUsers(Users user);
    }
}
