using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics_Dal;
using Cosmetics_Dal.Models;

namespace CosmeticsDTO
{
    public class Auto : AutoMapper.Profile
    {
        public Auto()
        {
            CreateMap<Categories, CategoryDTO>();
            CreateMap<CategoryDTO, Categories>();

            CreateMap<ProductDTO,Products>();
            CreateMap<Products, ProductDTO>();

            CreateMap<OrdersDTO, Orders>();
            CreateMap<Orders, OrdersDTO>();

            CreateMap<UsersDTO, Users>();
            CreateMap<Users, UsersDTO>();

        }

    }
}
