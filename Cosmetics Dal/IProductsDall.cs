using Cosmetics_Dal.Models;
using System.Collections.Generic;

namespace Cosmetics_Dal
{
    public interface IProductDal
    {
        List<Products> GetAllProducts();

        Products GetProductsById(int id);

        List<Products> GetProductsByCategory(int categoryId);

        List<Products> GetProductsWithZeroStock();

        void AddProducts(Products products);

        void DeleteProducts(int productId);

        void UpdateProducts(Products products);
    }
}
