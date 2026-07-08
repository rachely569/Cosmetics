using Cosmetics_Dal.Models;
using System;
using System.Collections.Generic;

namespace Cosmetics_Dal
{
    public interface IOrdersDal
    {
        List<Orders> GetAllOrders();

        Orders GetOrdersById(int id);

        List<Orders> GetOrdersByUserId(int userId);

        List<Orders> GetOrdersByDate(DateTime date);

        void AddOrders(Orders orders);

        void DeleteOrders(int ordersId);

        void UpdateOrders(Orders orders);
    }
}
