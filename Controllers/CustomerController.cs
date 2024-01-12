using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelAngular.Model;

namespace HotelAngular.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ILogger<CustomerController> _logger;

        private readonly HotelDbContext _context;

        public CustomerController(ILogger<CustomerController> logger, HotelDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            if (_context.Customer == null)
            {
                return NotFound();
            }
            return await _context.Customer.ToListAsync();
        }

        [HttpPost]
        [Route("insert")]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            if (_context.Customer == null)
            {
                return Problem("Entity set 'HotelDbContext.Customer'  is null.");
            }
            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        [HttpPost]
        [Route("delete/{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(int id)
        {
            if (_context.Customer == null)
            {
                return NotFound();
            }
            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int id)
        {
            if (_context.Customer == null)
            {
                return NotFound();
            }
            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        [HttpPost]
        [Route("edit")]
        public async Task<ActionResult<Customer>> EditCustomer(Customer customer)
        {
            if (_context.Customer == null)
            {
                return Problem("Entity set 'HotelDbContext.Customer'  is null.");
            }
            _context.Customer.Update(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }
    }
}
