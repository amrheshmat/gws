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
            List<Request> requests = await _repo.GetAll<Request>().ToListAsync();
            ViewBag.requests = requests;
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Edit(Request requestModel)
        {
            var rolePermissions = _repo.Filter<Request>(e => e.requestId == requestModel.requestId).ToList();
            var Request = _repo.Update<Request>(requestModel);
            _repo.SaveChanges();
            if (Request != null)
            {
                return RedirectToAction("Request");
            }
            return RedirectToAction("Request");
        }
    }
}
