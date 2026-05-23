using Cosmetics_Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics_Dal
{
    public interface IordersDal
    {
            List<Orders> GetAllOrders();

            Orders GetOrdersById(int id);

            void AddOrders(Orders orders);

            void DeleteOrders(int ordersId);

            void UpdateOrders(Orders orders);
        
    }
}
