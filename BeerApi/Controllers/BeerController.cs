using BeerApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeerApi.Controllers
{
    [Route("api/beer")]
    public class BeerController : ControllerBase
    {
        [HttpGet("all")]
        public IActionResult GetBeers()
        {
            return Ok("toutes les bières de la liste");
        }
        [HttpGet("{beerId}")]
        public IActionResult GetBeer(int beerId)
        {
            return Ok("la bière n°"+beerId.ToString()+" est retournée");
        }
        [HttpPost("")]
        public IActionResult PostBeer([FromBody] BeerModel beerModel)
        {
            return Ok("création d'une bière\n"+beerModel.ToString());
        }
        [HttpPut("")]
        public IActionResult PutBeer([FromBody] BeerModel beerModel)
        {
            return Ok("modification d'une bière\n" + beerModel.ToString());
        }
    }
}
