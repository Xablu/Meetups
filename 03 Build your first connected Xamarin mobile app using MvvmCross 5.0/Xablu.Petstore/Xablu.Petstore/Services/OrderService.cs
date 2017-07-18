using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xablu.Petstore.Models;
using Xablu.Petstore.Persistence;

namespace Xablu.Petstore.Services
{
    public class OrderService : IOrderService
    {
        private readonly PetstoreDbContext _dbContext;

        public OrderService(PetstoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Order PlaceOrder(Order order)
        {
            var dbOrder = new OrderDbContext();
            _dbContext.Orders.Add(dbOrder);
            _dbContext.SaveChanges();
            order.Id = dbOrder.OrderDbContextId;
            dbOrder.Order = order;
            _dbContext.SaveChanges();
            return order;
        }

        public bool DeleteOrder(string orderIdString)
        {
            long orderId;
            if (!long.TryParse(orderIdString, out orderId)) return false;
            var dbOrder = _dbContext.Orders.FirstOrDefault(dbo => dbo.OrderDbContextId == orderId);
            if (dbOrder == null) return false;
            _dbContext.Orders.Remove(dbOrder);
            _dbContext.SaveChanges();
            return true;
        }

        public Order FindOrderById(long orderId)
        {
            return _dbContext.Orders.FirstOrDefault(dbp => dbp.OrderDbContextId == orderId)?.Order;
        }

        public Dictionary<string, int?> GetOrderInventory()
        {
            return _dbContext.Orders.GroupBy(dbp => dbp.Order.Status, dbp => dbp.Order).ToDictionary(g => g.Key.ToString(), g =>  g.Select(o => o.Quantity).Sum());
        }



    }
}
