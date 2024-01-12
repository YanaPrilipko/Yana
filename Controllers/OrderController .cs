using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelAngular.Model;
using HotelAngular.ViewModels.Order;

namespace HotelAngular.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly ILogger<OrderController> _logger;

        private readonly HotelDbContext _context;

        public OrderController(ILogger<OrderController> logger, HotelDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            if (_context.Order == null)
            {
                return NotFound();
            }
            return await _context.Order
        .Include(o => o.House)
        .Include(o => o.Customer)
        .ToListAsync();
        }


        [HttpPost]
        [Route("insert")]
        public async Task<ActionResult<Order>> PostOrder(OrderCreateDto orderDto)
        {
            if (_context.Order == null)
            {
                return Problem("Entity set 'HotelDbContext.Order' is null.");
            }
            var order = orderDto.ToDbModel();
            _context.Order.Add(orderDto.ToDbModel());
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }


        [HttpPost]
        [Route("delete/{id}")]
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            if (_context.Order == null)
            {
                return NotFound();
            }
            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Order.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<ActionResult<Order>> GetOrderById(int id)
        {
            if (_context.Order == null)
            {
                return NotFound();
            }
            var order = await _context.Order
             .Include(o => o.House)
             .Include(o => o.Customer)
             .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        [HttpPost]
        [Route("edit")]
        public async Task<ActionResult<Order>> EditOrder(OrderCreateDto orderDto)
        {
            if (_context.Order == null)
            {
                return Problem("Entity set 'HotelDbContext.Order' is null.");
            }
            var order = orderDto.ToDbModel();
            _context.Order.Update(orderDto.ToDbModel());
            await _context.SaveChangesAsync();
            return CreatedAtAction("EditOrder", new { id = order.Id }, order);
        }

    }
}
