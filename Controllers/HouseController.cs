using HotelAngular.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelAngular.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HouseController : ControllerBase
    {

        private readonly ILogger<HouseController> _logger;

        private readonly HotelDbContext _context;

        public HouseController(ILogger<HouseController> logger, HotelDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<IEnumerable<House>>> GetHouses()
        {
            if(_context.House == null)
            {
                return NotFound();
            }
            return await _context.House.ToListAsync();
        }


        [HttpPost]
        [Route("insert")]
        public async Task<ActionResult<House>> PostHouse(House house)
        {
            if (_context.House == null)
            {
                return Problem("Entity set 'HotelDbContext.House'  is null.");
            }
            _context.House.Add(house);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetHouse", new { id = house.Id }, house);
        }

        [HttpPost]
        [Route("delete/{id}")]
        public async Task<ActionResult<House>> DeleteHouse(int id)
        {
            if (_context.House == null)
            {
                return NotFound();
            }
            var house = await _context.House.FindAsync(id);
            if (house == null)
            {
                return NotFound();
            }

            _context.House.Remove(house);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpGet]
        [Route("get/{id}")]
        public async Task<ActionResult<House>> GetHouseById(int id)
        {
            if (_context.House == null)
            {
                return NotFound();
            }
            var house = await _context.House.FindAsync(id);
            if (house == null)
            {
                return NotFound();
            }
            return house;
        }

        [HttpPost]
        [Route("edit")]
        public async Task<ActionResult<House>> EditHouse(House house)
        {
            if (_context.House == null)
            {
                return Problem("Entity set 'HotelDbContext.House'  is null.");
            }
            _context.House.Update(house);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHouse", new { id = house.Id }, house);
        }
    }
}