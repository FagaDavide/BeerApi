using Microsoft.AspNetCore.Mvc;

namespace BeerApi.Controllers
{
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet("")]
        public IActionResult GetHome()
        {
            return Ok("Welcome");
        }
    }
}
