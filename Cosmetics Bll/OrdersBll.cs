using Cosmetics_Dal;
using Cosmetics_Dal.Models;
using System;
using System.Collections.Generic;

namespace Cosmetics_Bll
{
    public class OrdersBll : IOrdersBll
    {
        private readonly IOrdersDal _ordersDal;

        public OrdersBll(IOrdersDal ordersDal)
        {
            _ordersDal = ordersDal;
        }

        public void AddOrders(Orders orders)
        {
            _ordersDal.AddOrders(orders);
        }

        public void DeleteOrders(int ordersId)
        {
            _ordersDal.DeleteOrders(ordersId);
        }

        public List<Orders> GetAllOrders()
        {
            return _ordersDal.GetAllOrders();
        }

        public Orders GetOrdersById(int id)
        {
            return _ordersDal.GetOrdersById(id);
        }

        public List<Orders> GetOrdersByUserId(int userId)
        {
            return _ordersDal.GetOrdersByUserId(userId);
        }

        public List<Orders> GetOrdersByDate(DateTime date)
        {
            return _ordersDal.GetOrdersByDate(date);
        }

        public void UpdateOrders(Orders orders)
        {
            _ordersDal.UpdateOrders(orders);
        }
    }
}
