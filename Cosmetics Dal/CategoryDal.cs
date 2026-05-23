using Cosmetics_Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        public List<Categories> GetAllCategories()
        {
            return db.Categories.ToList();
        }

        public Categories GetCategoriesById(int id)
        {
            return db.Categories.Find(id);
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