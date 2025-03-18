using Microsoft.AspNetCore.Mvc;
using MWS.Infrustructure.Repositories;

namespace SampleMVC.Controllers
{
    public class AccountController : Controller
    {
        private IRepository _repo;
        public AccountController(IRepositoryFactory repo)
        {
            _repo = repo.Create("AGGRDB");
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AccessDenied()
        {
            return RedirectToAction("AccessDenied", "admin");
        }

    }
}
