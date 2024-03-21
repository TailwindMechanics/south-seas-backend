//path: src\Controllers\RootController.cs

using Microsoft.AspNetCore.Mvc;

namespace SouthSeas.Controllers
{
    [ApiController]
    public class RootController : ControllerBase
    {
        [HttpGet("/")]
        public IActionResult Root()
            => Ok($"Hello.");
    }
}
