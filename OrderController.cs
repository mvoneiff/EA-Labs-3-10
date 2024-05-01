using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HTTPRoutingDemo.Database.Models;
using HTTPRoutingDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace HTTPRoutingDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }
    
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return _orderService.GetOrders();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _orderService.GetOrderAsync(id);
            if (order != null)
            {
                return order;
            }
            else
            {
                return NotFound();
            }

            
        }

        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            await _orderService.CreateOrderAsync(order);
            return CreatedAtAction(nameof(GetOrder), new { id = order.OrderId }, order);
        }
     
        [HttpPut("{id}")]
        public async Task<ActionResult> PutOrder(int id, Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest();
            }

            await _orderService.UpdateOrderAsync(order);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            await _orderService.DeleteOrderAsync(id);
            return NoContent();
        }
    }
}

