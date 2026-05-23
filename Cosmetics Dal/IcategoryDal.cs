using Cosmetics_Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics_Dal
{
    public interface ICategoriesDal

    {
        List<Categories> GetAllCategories();

        Categories GetCategoriesById(int id);

        void AddCategories(Categories category);

        void DeleteCategories(int categoryId);

        void UpdateCategories(Categories category);


    }
}
