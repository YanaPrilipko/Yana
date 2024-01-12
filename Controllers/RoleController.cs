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
    public class RoleController : ControllerBase
    {

        private readonly ILogger<RoleController> _logger;

        private readonly HotelDbContext _context;

        public RoleController(ILogger<RoleController> logger, HotelDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
        {
            if (_context.Role == null)
            {
                return NotFound();
            }
            return await _context.Role.ToListAsync();
        }

        [HttpPost]
        [Route("insert")]
        public async Task<ActionResult<Role>> PostRole(Role role)
        {
            if (_context.Role == null)
            {
                return Problem("Entity set 'HotelDbContext.Role'  is null.");
            }
            _context.Role.Add(role);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRole", new { id = role.Id }, role);
        }

        [HttpPost]
        [Route("delete/{id}")]
        public async Task<ActionResult<Role>> DeleteRole(int id)
        {
            if (_context.Role == null)
            {
                return NotFound();
            }
            var role = await _context.Role.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            _context.Role.Remove(role);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<ActionResult<Role>> GetRoleById(int id)
        {
            if (_context.Role == null)
            {
                return NotFound();
            }
            var role = await _context.Role.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            return role;
        }

        [HttpPost]
        [Route("edit")]
        public async Task<ActionResult<Role>> EditRole(Role role)
        {
            if (_context.Role == null)
            {
                return Problem("Entity set 'HotelDbContext.Role'  is null.");
            }
            _context.Role.Update(role);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRole", new { id = role.Id }, role);
        }
    }
}
