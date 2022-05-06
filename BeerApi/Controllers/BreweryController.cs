using BeerApi.DataBase;
using BeerApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreweryController : ControllerBase
    {
        private readonly BeerDbContext context;

        public BreweryController(BeerDbContext ctx)
        {
            context = ctx;
        }

        // GET: api/Brewery
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brewery>>> GetBreweries()
        {
            return await context.Breweries.ToListAsync();
        }

        // GET: api/Brewery/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Brewery>> GetBrewery(ulong id)
        {
            var brewery = await context.Breweries.FindAsync(id);

            if (brewery == null)
                return NotFound();

            return brewery;
        }

        // PUT: api/Brewery/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrewery(Brewery brewery)
        {
            if (!BreweryExists(brewery.Id))
                return NotFound();

            context.Entry(brewery).State = EntityState.Modified;

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

        // POST: api/Brewery
        [HttpPost]
        public async Task<ActionResult<Brewery>> PostBrewery(Brewery brewery)
        {
            context.Breweries.Add(brewery);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetBrewery", new { id = brewery.Id }, brewery);
        }

        // DELETE: api/Brewery/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrewery(ulong id)
        {
            var brewery = await context.Breweries.FindAsync(id);
            if (brewery == null)
                return NotFound();

            context.Breweries.Remove(brewery);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool BreweryExists(ulong id)
        {
            return context.Breweries.Any(e => e.Id == id);
        }
    }
}
