using BeerApi.DataBase;
using BeerApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly BeerDbContext context;

        public RoleController(BeerDbContext ctx)
        {
            context = ctx;
        }

        // GET: api/Role
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
        {
            return await context.Roles.ToListAsync();
        }

        // GET: api/Role/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRole(ulong id)
        {
            var role = await context.Roles.FindAsync(id);

            if (role == null)
                return NotFound();

            return role;
        }

        // PUT: api/Role/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(Role role)
        {
            if (!RoleExists(role.Id))
                return NotFound();

            context.Entry(role).State = EntityState.Modified;

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

        // POST: api/Role
        [HttpPost]
        public async Task<ActionResult<Role>> PostRole(Role role)
        {
            context.Roles.Add(role);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetRole", new { id = role.Id }, role);
        }

        // DELETE: api/Role/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(ulong id)
        {
            var role = await context.Roles.FindAsync(id);
            if (role == null)
                return NotFound();

            context.Roles.Remove(role);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoleExists(ulong id) { return context.Roles.Any(e => e.Id == id); }
    }
}
