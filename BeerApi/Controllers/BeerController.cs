using BeerApi.DataBase;
using BeerApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private readonly BeerDbContext context;

        public BeerController(BeerDbContext ctx)
        {
            context = ctx;
        }

        // GET: api/Beer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Beer>>> GetBeers()
        {
            return await context.Beers.ToListAsync();
        }

        // GET: api/Beer/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Beer>> GetBeer(ulong id)
        {
            var beer = await context.Beers.FindAsync(id);

            if (beer == null)
                return NotFound();

            return beer;
        }

        // PUT: api/Beer/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBeer(Beer beer)
        {
            if (!BeerExists(beer.Id))
                return NotFound();

            context.Entry(beer).State = EntityState.Modified;

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

        // POST: api/Beer
        [HttpPost]
        public async Task<ActionResult<Beer>> PostBeer(Beer beer)
        {
            context.Beers.Add(beer);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetBeer", new { id = beer.Id }, beer);
        }

        // DELETE: api/Beer/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBeer(ulong id)
        {
            var beer = await context.Beers.FindAsync(id);
            if (beer == null)
                return NotFound();

            context.Beers.Remove(beer);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool BeerExists(ulong id)
        {
            return context.Beers.Any(e => e.Id == id);
        }
    }
}

