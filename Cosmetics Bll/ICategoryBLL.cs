using Cosmetics_Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics_Bll
{
    public interface ICategoryBLL
    {
        List<Categories> GetAllCategories();

        Categories GetCategoriesById(int id);

        void addCategories(Categories coursesTbl);

        void DeleteCategories(int coursesId);

        void UpdateCategories(Categories coursesTbl);

    }
}
