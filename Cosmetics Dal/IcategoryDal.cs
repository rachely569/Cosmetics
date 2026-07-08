using Cosmetics_Dal.Models;
using System.Collections.Generic;

namespace Cosmetics_Dal
{
    public interface ICategoriesDal
    {
        List<Categories> GetAllCategories();

        Categories GetCategoriesById(int id);

        Categories GetCategoryByName(string categoryName);

        Categories GetCategoryByCode(int categoryCode);

        void AddCategories(Categories category);

        void DeleteCategories(int categoryId);

        void UpdateCategories(Categories category);
    }
}
