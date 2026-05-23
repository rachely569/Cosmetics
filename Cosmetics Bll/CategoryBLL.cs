using Cosmetics_Dal;
using Cosmetics_Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics_Bll
{
    public class CategoryBLL : ICategoryBLL
    {
        ICategoriesDal categoryDal;
        public CategoryBLL(ICategoriesDal categoryDal)
        {
            this.categoryDal = categoryDal;
        }

        public void addCategories(Categories category)
        {
            categoryDal.AddCategories(category);
        }

        public void DeleteCategories(int categoryId)
        {
            categoryDal.DeleteCategories(categoryId);
        }

        public List<Categories> GetAllCategories()
        {
            return categoryDal.GetAllCategories();
        }

        public Categories GetCategoriesById(int id)
        {
            return categoryDal.GetCategoriesById(id);
        }

        public void UpdateCategories(Categories category)
        {
            categoryDal.UpdateCategories(category);
        }

    }
}
