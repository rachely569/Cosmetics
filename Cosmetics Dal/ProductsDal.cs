using Cosmetics_Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
            else
            {
                throw new ArgumentException($"Product with ID {ProductId} could not be found to delete.");
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

        public List<Products> GetProductsByCategory(int categoryId)
        {
            return db.Products.Where(p => p.CategoryId == categoryId).ToList();
        }

        // Used by the admin dashboard to show low/no-stock alerts
        public List<Products> GetProductsWithZeroStock()
        {
            return db.Products.Where(p => p.StockQuantity == 0).ToList();
        }

        public void UpdateProducts(Products products)
        {
            // Find the existing record in the database using the incoming object's ID
            var currentProduct = db.Products.Find(products.ProductId);

            // Null check prevents the application from crashing if the ID doesn't exist
            if (currentProduct != null)
            {
                // Update every editable field with the values sent from the incoming payload
                currentProduct.ProductName = products.ProductName;
                currentProduct.Price = products.Price;
                currentProduct.CategoryId = products.CategoryId;
                currentProduct.Description = products.Description;
                currentProduct.StockQuantity = products.StockQuantity;
                currentProduct.ImageSrc = products.ImageSrc;

                db.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"Product with ID {products.ProductId} could not be found to update.");
            }
        }
    }
}
