#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeerApi.DataBase;
using BeerApi.Models;

namespace BeerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerUserController : ControllerBase
    {
        private readonly BeerDbContext context;

        public BeerUserController(BeerDbContext ctx)
        {
            context = ctx;
        }

        // GET: api/BeerUser
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BeerUser>>> GetBeerUser()
        {
            return await context.BeerUsers.ToListAsync();
        }

        // GET: api/BeerUser/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<BeerUser>> GetBeerUser(ulong id)
        {
            var beerUser = await context.BeerUsers.FindAsync(id);

            if (beerUser == null)
                return NotFound();

            return beerUser;
        }

        // PUT: api/BeerUser/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBeerUser(BeerUser beerUser)
        {
            if (!BeerUserExists(beerUser.Id))
                return NotFound();

            context.Entry(beerUser).State = EntityState.Modified;

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

        // POST: api/BeerUser
        [HttpPost]
        public async Task<ActionResult<BeerUser>> PostBeerUser(BeerUser beerUser)
        {
            context.BeerUsers.Add(beerUser);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetBeerUser", new { id = beerUser.Id }, beerUser);
        }

        // DELETE: api/BeerUser/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBeerUser(ulong id)
        {
            var beerUser = await context.BeerUsers.FindAsync(id);
            if (beerUser == null)
                return NotFound();

            context.BeerUsers.Remove(beerUser);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool BeerUserExists(ulong id)
        {
            return context.BeerUsers.Any(e => e.Id == id);
        }
    }
}
