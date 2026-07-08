using Cosmetics_Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmetics_Dal
{
    public class OrdersDal : IOrdersDal
    {
        private readonly SHOPContext db;

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
            var order = db.Orders.Find(OrdersId);
            if (order != null)
            {
                db.Orders.Remove(order);
                db.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"Order with ID {OrdersId} could not be found to delete.");
            }
        }

        public List<Orders> GetAllOrders()
        {
            return db.Orders.ToList();
        }

        public Orders GetOrdersById(int id)
        {
            return db.Orders.Find(id);
        }

        public List<Orders> GetOrdersByUserId(int userId)
        {
            return db.Orders.Where(o => o.UserId == userId).ToList();
        }

        // Bonus requirement: lookup by date (matches the calendar day, ignoring time of day)
        public List<Orders> GetOrdersByDate(DateTime date)
        {
            return db.Orders.Where(o => o.OrderDate.Date == date.Date).ToList();
        }

        public void UpdateOrders(Orders order)
        {
            var existingOrder = db.Orders.Find(order.OrderId);
            if (existingOrder != null)
            {
                existingOrder.TotalAmount = order.TotalAmount;
                existingOrder.OrderDate = order.OrderDate;
                db.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"Order with ID {order.OrderId} could not be found to update.");
            }
        }
    }
}
