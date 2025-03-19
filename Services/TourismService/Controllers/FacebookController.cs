using Microsoft.AspNetCore.Mvc;

namespace SampleMVC.Controllers
{
    public class FacebookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
