//path: src\Controllers\MainController.cs

using Microsoft.AspNetCore.Mvc;


namespace SouthSeas.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {
        [HttpGet("hello/world")]
        public IActionResult Get()
        {
            return Ok("Hello, World!");
        }
    }
}
