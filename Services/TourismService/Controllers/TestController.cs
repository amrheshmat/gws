using Microsoft.AspNetCore.Mvc;

namespace SampleMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            // Simulate an unhandled exception
            throw new InvalidOperationException("Something went wrong!");
        }
    }
}
