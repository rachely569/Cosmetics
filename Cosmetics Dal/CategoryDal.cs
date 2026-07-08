using Cosmetics_Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmetics_Dal
{
    public class CategoryDal : ICategoriesDal
    {
        private readonly SHOPContext db;

        public CategoryDal(SHOPContext db)
        {
            this.db = db;
        }

        public void AddCategories(Categories categories)
        {
            db.Categories.Add(categories);
            db.SaveChanges();
        }

        public void DeleteCategories(int CategoryId)
        {
            // Direct Find avoids pulling the whole table into memory
            var category = db.Categories.Find(CategoryId);
            if (category != null)
            {
                db.Categories.Remove(category);
                db.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"Category with ID {CategoryId} could not be found to delete.");
            }
        }

        public List<Categories> GetAllCategories()
        {
            return db.Categories.ToList();
        }

        public Categories GetCategoriesById(int id)
        {
            return db.Categories.Find(id);
        }

        public Categories GetCategoryByName(string categoryName)
        {
            return db.Categories.FirstOrDefault(c => c.CategoryName == categoryName);
        }

        // "Code" here refers to the category's identifying number (CategoryId)
        public Categories GetCategoryByCode(int categoryCode)
        {
            return db.Categories.Find(categoryCode);
        }

        public void UpdateCategories(Categories category)
        {
            // Direct database lookup using Find
            var existingCategory = db.Categories.Find(category.CategoryId);

            // Safety guard checking if the category actually exists
            if (existingCategory != null)
            {
                // Correctly assign incoming property values onto the database entity
                existingCategory.CategoryName = category.CategoryName;

                db.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"Category with ID {category.CategoryId} could not be found to update.");
            }
        }
    }
}
