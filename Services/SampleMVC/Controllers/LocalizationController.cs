using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MWS.Business.Shared;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;
using SampleMVC.Models;

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
            List<Language> languages = await _repo.GetAll<Language>().ToListAsync();
            List<LocalizationModel> model = new List<LocalizationModel>();
            foreach (Localization localization in localizations)
            {
                LocalizationModel localizationModel = new LocalizationModel();
                localizationModel.localizeId = localization.localizeId;
                localizationModel.languageId = localization.languageId;
                localizationModel.keyName = localization.keyName;
                localizationModel.value = localization.value;
                localizationModel.languageName = _repo.Filter<Language>(e => e.languageId == localization.languageId).FirstOrDefault()?.languageName;
                model.Add(localizationModel);
            }
            ViewBag.localizations = model;
            ViewBag.languages = languages;
            return View();

        }
        [AuthAttribute("edit", "Localization")]
        [HttpPost]
        [Route("Localization/Edit")]
        public async Task<IActionResult> Edit([FromBody] Localization localizationModel)
        {
            var oldLocalize = await _repo.Filter<Localization>(e => e.localizeId == localizationModel.localizeId).FirstOrDefaultAsync();
            if (oldLocalize != null)
            {
                var localize = _repo.Update(localizationModel);
                await _repo.SaveChangesAsync();
                if (localize?.localizeId != null)
                {
                    return Ok("Updated");
                }
            }
            return Ok("Error");
        }
        [AuthAttribute("add", "Localization")]
        [HttpPost]
        [Route("Localization/Add")]
        public async Task<IActionResult> Add([FromBody] Localization localizationModel)
        {

            var oldLocalize = await _repo.Filter<Localization>(e => e.languageId == localizationModel.languageId && e.keyName == localizationModel.keyName).FirstOrDefaultAsync();
            if (oldLocalize != null)
            {

                return Ok("exsits");
            }
            else
            {
                var localize = await _repo.CreateAsync(localizationModel);
                await _repo.SaveChangesAsync();
                if (localize?.localizeId != null)
                {
                    return Ok("Added");
                }
            }
            return Ok("Error");
        }
        [AuthAttribute("delete", "Localization")]
        [HttpGet]
        [Route("Localization/Delete/{id}")]
        public async Task<string> Delete(int id)
        {
            var localization = _repo.Filter<Localization>(e => e.localizeId == id).FirstOrDefault();
            if (localization != null)
            {
                _repo.Delete<Localization>(localization);
                await _repo.context.SaveChangesAsync();
                return "Deleted";
            }
            return "NotFond";
        }
    }
}
