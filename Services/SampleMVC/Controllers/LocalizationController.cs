using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MWS.Business.Shared;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;

namespace SampleMVC.Controllers
{
    public class LocalizationController : Controller
    {
        private IRepository _repo;
        public LocalizationController(IRepositoryFactory repo)
        {
            _repo = repo.Create("AGGRDB");
        }
        [AuthAttribute("Localization", "Localization")]
        public async Task<IActionResult> Localization()//index page
        {
            List<Localization> localizations = await _repo.GetAll<Localization>().ToListAsync();
            ViewBag.localizations = localizations;
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Edit(Localization lcalizationModel)
        {
            var rolePermissions = _repo.Filter<Localization>(e => e.languageId == lcalizationModel.localizeId).ToList();
            var Language = _repo.Update<Localization>(lcalizationModel);
            _repo.SaveChanges();
            if (Language != null)
            {
                return RedirectToAction("Localization");
            }
            return RedirectToAction("Localization");
        }
    }
}
