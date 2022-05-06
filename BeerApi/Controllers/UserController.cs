using BeerApi.DataBase;
using BeerApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
