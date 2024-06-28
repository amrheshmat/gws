using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MWS.Business.Shared;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;

namespace SampleMVC.Controllers
{
    public class RequestController : Controller
    {
        private IRepository _repo;
        public RequestController(IRepositoryFactory repo)
        {
            _repo = repo.Create("AGGRDB");
        }
        [AuthAttribute("request", "request")]
        public async Task<IActionResult> Request()//index page
        {
            List<Booking> requests = await _repo.GetAll<Booking>().ToListAsync();
            ViewBag.requests = requests;
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Edit(Booking requestModel)
        {
            var rolePermissions = _repo.Filter<Booking>(e => e.requestId == requestModel.requestId).ToList();
            var Request = _repo.Update<Booking>(requestModel);
            _repo.SaveChanges();
            if (Request != null)
            {
                return RedirectToAction("Request");
            }
            return RedirectToAction("Request");
        }
    }
}
