using Cosmetics_Dal.Models;
using System.Collections.Generic;

namespace Cosmetics_Bll
{
    public interface IProductsBll
    {
        List<Products> GetAllProducts();

        Products GetProductsById(int id);

        List<Products> GetProductsByCategory(int categoryId);

        List<Products> GetProductsWithZeroStock();

        void AddProducts(Products products);

        void DeleteProducts(int productsId);

        void UpdateProducts(Products products);
    }
}
