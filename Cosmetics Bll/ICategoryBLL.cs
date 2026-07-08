using Cosmetics_Dal.Models;
using System.Collections.Generic;

namespace Cosmetics_Bll
{
    public interface ICategoryBLL
    {
        List<Categories> GetAllCategories();

        Categories GetCategoriesById(int id);

        Categories GetCategoryByName(string categoryName);

        Categories GetCategoryByCode(int categoryCode);

        void addCategories(Categories coursesTbl);

        void DeleteCategories(int coursesId);

        void UpdateCategories(Categories coursesTbl);
    }
}
