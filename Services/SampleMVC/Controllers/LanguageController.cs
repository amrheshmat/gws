using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MWS.Business.Shared;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;

namespace SampleMVC.Controllers
{
    public class LanguageController : Controller
    {
        private IRepository _repo;
        public LanguageController(IRepositoryFactory repo)
        {
            _repo = repo.Create("AGGRDB");
        }
        [AuthAttribute("language", "language")]
        public async Task<IActionResult> Language()//index page
        {
            List<Language> languages = await _repo.GetAll<Language>().ToListAsync();
            ViewBag.languages = languages;
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Edit(Language languageModel)
        {
            var rolePermissions = _repo.Filter<Language>(e => e.languageId == languageModel.languageId).ToList();
            var Language = _repo.Update<Language>(languageModel);
            _repo.SaveChanges();
            if (Language != null)
            {
                return RedirectToAction("Language");
            }
            return RedirectToAction("Language");
        }
    }
}
