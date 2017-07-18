using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xablu.Petstore.Models;

namespace Xablu.Petstore.Services
{
    public interface IOrderService
    {
        Order PlaceOrder(Order order);
        bool DeleteOrder(string orderId);
        Order FindOrderById(long orderId);
        Dictionary<string, int?> GetOrderInventory();
    }
}
