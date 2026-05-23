using Cosmetics_Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics_Dal
{
    public class OrdersDal : IordersDal
    {
        SHOPContext db;

        public OrdersDal(SHOPContext db)
        {
            this.db = db;
        }

        public void AddOrders(Orders orders)
        {
            db.Orders.Add(orders);
            db.SaveChanges();
        }

        public void DeleteOrders(int OrdersId)
        {
            var Order = db.Orders.ToList().Find(x => x.OrderId == OrdersId);
            db.Orders.Remove(Order);
            db.SaveChanges();
        }


        public List<Orders> GetAllOrders()
        {
            return db.Orders.ToList();
        }

        public Orders GetOrdersById(int id)
        {
            return db.Orders.ToList().Find(x => x.OrderId == id);
        }

        public void UpdateOrders(Orders order)
        {
            var orders = db.Orders.ToList().Find(x => x.OrderId == order.OrderId);
            orders.TotalAmount = order.TotalAmount;
            db.SaveChanges();
        }
    }
}
