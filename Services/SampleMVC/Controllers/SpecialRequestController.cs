using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MWS.Business.Shared;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;

namespace SampleMVC.Controllers
{
    public class SpecialRequestController : Controller
    {
        private IRepository _repo;
        public SpecialRequestController(IRepositoryFactory repo)
        {
            _repo = repo.Create("AGGRDB");
        }
        [AuthAttribute("SpecialRequest", "SpecialRequest")]
        public async Task<IActionResult> SpecialRequest()//index page
        {
            List<SpecialRequest> specialRequests = await _repo.GetAll<SpecialRequest>().ToListAsync();
            ViewBag.specialRequests = specialRequests;
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Edit(SpecialRequest specialRequestModel)
        {
            var rolePermissions = _repo.Filter<SpecialRequest>(e => e.specialRequestId == specialRequestModel.specialRequestId).ToList();
            var SpecialRequest = _repo.Update<SpecialRequest>(specialRequestModel);
            _repo.SaveChanges();
            if (SpecialRequest != null)
            {
                return RedirectToAction("SpecialRequest");
            }
            return RedirectToAction("SpecialRequest");
        }
    }
}
