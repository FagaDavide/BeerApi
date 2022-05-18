/*====================================================================*\
Name ........ : HomeController.cs
Role ........ : If the root is asked, a message is shown
Author ...... : Davide Faga
Date ........ : 18.05.2022
\*====================================================================*/
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
