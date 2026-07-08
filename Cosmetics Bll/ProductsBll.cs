using Cosmetics_Dal;
using Cosmetics_Dal.Models;
using System.Collections.Generic;

namespace Cosmetics_Bll
{
    public class ProductsBll : IProductsBll
    {
        private readonly IProductDal _productDal;

        public ProductsBll(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void AddProducts(Products products)
        {
            _productDal.AddProducts(products);
        }

        public void DeleteProducts(int productsId)
        {
            _productDal.DeleteProducts(productsId);
        }

        public List<Products> GetAllProducts()
        {
            return _productDal.GetAllProducts();
        }

        public Products GetProductsById(int id)
        {
            return _productDal.GetProductsById(id);
        }

        public List<Products> GetProductsByCategory(int categoryId)
        {
            return _productDal.GetProductsByCategory(categoryId);
        }

        public List<Products> GetProductsWithZeroStock()
        {
            return _productDal.GetProductsWithZeroStock();
        }

        public void UpdateProducts(Products products)
        {
            _productDal.UpdateProducts(products);
        }
    }
}
