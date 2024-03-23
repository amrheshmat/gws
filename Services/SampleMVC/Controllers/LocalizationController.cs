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
			List<Language> languages = await _repo.GetAll<Language>().ToListAsync();
			ViewBag.localizations = localizations;
			ViewBag.languages = languages;
			return View();

		}
		[HttpPost]
		[Route("Localization/Edit")]
		public async Task<IActionResult> Edit([FromBody] Localization localizationModel)
		{
			var oldLocalize = await _repo.Filter<Localization>(e => e.languageId == localizationModel.languageId && e.keyName == localizationModel.keyName).FirstOrDefaultAsync();
			if (oldLocalize != null)
			{
				var localize = _repo.Update(localizationModel);
				await _repo.SaveChangesAsync();
				if (localize?.localizeId != null)
				{
					return Ok("Added");
				}
			}
			return Ok("Updated");
		}
		[HttpPost]
		[Route("Localization/Add")]
		public async Task<IActionResult> Add([FromBody] Localization localizationModel)
		{

			var oldLocalize = await _repo.Filter<Localization>(e => e.localizeId == localizationModel.localizeId).FirstOrDefaultAsync();
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
	}
}
