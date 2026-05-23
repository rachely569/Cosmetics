using Cosmetics_Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics_Bll
{
    public interface IProductsBll
    {
        List<Products> GetAllProducts();

        Products GetProductsById(int id);

        void AddProducts(Products products);

        void DeleteProducts(int productsId);

        void UpdateProducts(Products products);
    }
}
