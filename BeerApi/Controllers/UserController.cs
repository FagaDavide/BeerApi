using BeerApi.DataBase;
using BeerApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BeerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly BeerDbContext context;

        public UserController(BeerDbContext ctx)
        {
            context = ctx;
        }
        /////////////////////////////
        ///TEST
        /////////////////////////////
        
        [HttpGet("admin")]
        [Authorize(Roles = "Administrator")]
        public IActionResult Admin()
        {
            var currentUser = GetCurrentUser();
            return Ok($"/Admin\nHi {currentUser.Username}, you are an {currentUser.Role.Name}");
        }
       
        [HttpGet("brewer")]
        [Authorize(Roles = "Administrator, Brewer")]
        public IActionResult Brewer()
        {
            var currentUser = GetCurrentUser();
            return Ok($"/Brewer\nHi {currentUser.Username}, you are a {currentUser.Role.Name}");
        }

        [HttpGet("drinker")]
        [Authorize(Roles = "Administrator, Brewer, Drinker")]
        public IActionResult Drinker()
        {
            var currentUser = GetCurrentUser();
            return Ok($"/Drinker\nHi {currentUser.Username}, you are a {currentUser.Role.Name}");
        }

        [HttpGet("whoiam")]
        [Authorize]
        public IActionResult WhoIam()
        {
            var currentUser = GetCurrentUser();
            return Ok($"/WhoIam\nHi {currentUser.Username}, you are an {currentUser.Role.Name}");
        }

        private User GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity == null)
                return null;

            var userClaims = identity.Claims;

            return new User
            {
                Username = userClaims.FirstOrDefault(user => user.Type == ClaimTypes.NameIdentifier)?.Value,
                Email = userClaims.FirstOrDefault(user => user.Type == ClaimTypes.Email)?.Value,
                Role = new Role() { Name = userClaims.FirstOrDefault(user => user.Type == ClaimTypes.Role)?.Value }
            };
        }

        /////////////////////////////
        ///END TEST
        /////////////////////////////
        
        
        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await context.Users.ToListAsync();
        }

        // GET: api/User/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(ulong id)
        {
            var user = await context.Users.FindAsync(id);

            if (user == null)
                return NotFound();

            return user;
        }

        // PUT: api/User/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(User user)
        {
            if (!UserExists(user.Id))
                return NotFound();

            context.Entry(user).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            context.Users.Add(user);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/User/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(ulong id)
        {
            var user = await context.Users.FindAsync(id);
            if (user == null)
                return NotFound();

            context.Users.Remove(user);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(ulong id)
        {
            return context.Users.Any(e => e.Id == id);
        }
    }
}
