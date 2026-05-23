using Cosmetics_Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics_Dal
{
    public class ProductsDal : IProductDal
    {
        private readonly SHOPContext db;

        public ProductsDal(SHOPContext db)
        {
            this.db = db;
        }

        public void AddProducts(Products products)
        {
            db.Products.Add(products);
            db.SaveChanges();
        }

        public void DeleteProducts(int ProductId)
        {
            // Using Find() directly on the DbSet searches the local context first, then database
            var product = db.Products.Find(ProductId);
            if (product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
            }
        }

        public List<Products> GetAllProducts()
        {
            return db.Products.ToList();
        }

        public Products GetProductsById(int id)
        {
            return db.Products.Find(id);
        }

        public void UpdateProducts(Products products)
        {
            // Find the existing record in the database using the incoming object's ID
            var currentProduct = db.Products.Find(products.ProductId);

            // Null check prevents the application from crashing if the ID doesn't exist
            if (currentProduct != null)
            {
                // Update the fields with the new values sent from the incoming payload
                currentProduct.ProductName = products.ProductName;
                currentProduct.Price = products.Price;
                currentProduct.CategoryId = products.CategoryId;
                // Add any other specific product fields you want updated here

                db.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"Product with ID {products.ProductId} could not be found to update.");
            }
        }
    }
}