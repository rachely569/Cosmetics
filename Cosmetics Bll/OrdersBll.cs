using Cosmetics_Dal;
using Cosmetics_Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics_Bll
{
    public class OrdersBll : IOrdersBll
    {
        private readonly IordersDal _ordersDal;

        public OrdersBll(IordersDal ordersDal)
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

        public void UpdateOrders(Orders orders)
        {
            _ordersDal.UpdateOrders(orders);
        }
    }
}