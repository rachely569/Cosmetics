using Cosmetics_Dal;
using Cosmetics_Dal.Models;
using System.Collections.Generic;

namespace Cosmetics_Bll
{
    public class CategoryBLL : ICategoryBLL
    {
        private readonly ICategoriesDal categoryDal;

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

        public Categories GetCategoryByName(string categoryName)
        {
            return categoryDal.GetCategoryByName(categoryName);
        }

        public Categories GetCategoryByCode(int categoryCode)
        {
            return categoryDal.GetCategoryByCode(categoryCode);
        }

        public void UpdateCategories(Categories category)
        {
            categoryDal.UpdateCategories(category);
        }
    }
}
