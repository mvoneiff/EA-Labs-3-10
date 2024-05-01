using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using HTTPRoutingDemo.Database.Models;
using HTTPRoutingDemo.Database;
using Microsoft.EntityFrameworkCore;

namespace HTTPRoutingDemo.Repositories
{
    public class OrderRepository
    {
        private readonly CRMContext _context;

        public OrderRepository(CRMContext context)
        {
            _context = context;
        }

        public IEnumerable<Order> GetOrders()
        {
            return _context.Orders;
        }

        public async Task<Order?> FindOrderAsync(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == id);
        }

        public async Task CreateOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await FindOrderAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> UpdateOrderAsync(Order order)
        {
            var dbOrder = await FindOrderAsync(order.OrderId);
            if (dbOrder != null)
            {
                dbOrder.OrderDate = order.OrderDate;
                dbOrder.NumberOfItemsInOrder = order.NumberOfItemsInOrder;
                dbOrder.OrderTotal = order.OrderTotal;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }


    }
}

