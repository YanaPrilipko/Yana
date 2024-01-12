using HotelAngular.Helpers;
using HotelAngular.Model;
using HotelAngular.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelAngular.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;

        private readonly HotelDbContext _context;

        private readonly ISecurePasswordHelper _securePasswordHelper; 

        public UserController(ILogger<UserController> logger, HotelDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        [HttpPost]
        [Route("auth")]
        public async Task<ActionResult<User>> Login(UserDto userDto)
        {
            if (_context.User == null)
            {
                return Problem("Entity set 'HotelDbContext.User' is null.");
            }
           
            var user = await _context.User.FirstOrDefaultAsync(u => u.Email == userDto.Email && u.Password == userDto.Password);

            if (user == null)
            {
                return NotFound("Invalid email or password");
            }

            return user;
        }

    }
}
