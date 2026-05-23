using Cosmetics_Dal;
using Cosmetics_Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics_Bll
{
    public class ProductsBll : IProductsBll
    {
       
        IProductDal _productDal;

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

        public void UpdateProducts(Products products)
        {
            _productDal.UpdateProducts(products);
        }
    }
}