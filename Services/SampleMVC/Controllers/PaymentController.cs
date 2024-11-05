using Microsoft.AspNetCore.Mvc;

namespace SampleMVC.Controllers
{
    public class PaymentController : Controller
    {
		[Route("payment/result/status/{id}")]
        public IActionResult Index(int id)
        {
            ViewBag.paymentResult = id;
            return View();
        }
    }
}
