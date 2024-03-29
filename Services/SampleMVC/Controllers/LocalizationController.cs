using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MWS.Business.Shared;
using MWS.Business.Shared.Data.Models;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;
using SampleMVC.Models;
using TripBusiness.Ibusiness;

namespace SampleMVC.Controllers
{
	public class LocalizationController : Controller
	{
		private IRepository _repo;
		private ILocalizationService _localizationService;
		public LocalizationController(ILocalizationService localizationService, IRepositoryFactory repo)
		{
			_repo = repo.Create("AGGRDB");
			_localizationService = localizationService;
		}
		[AuthAttribute("localization", "localization")]
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
		[AuthAttribute("edit", "localization")]
		[HttpPost]
		[Route("localization/Edit")]
		public async Task<Response> Edit([FromBody] Localization localizationModel)
		{
			Response response = new Response();
			response.Title = _localizationService.Localize("Update");
			var oldLocalize = await _repo.Filter<Localization>(e => e.localizeId == localizationModel.localizeId).FirstOrDefaultAsync();
			if (oldLocalize != null)
			{
				var localize = _repo.Update(localizationModel);
				await _repo.SaveChangesAsync();
				if (localize?.localizeId != null)
				{
					response.Message = _localizationService.Localize("Updated");
					response.Status = true;
					return response;
				}
			}
			response.Message = _localizationService.Localize("UpdatedError");
			response.Status = false;
			return response;
		}
		[AuthAttribute("add", "localization")]
		[HttpPost]
		[Route("localization/Add")]
		public async Task<Response> Add([FromBody] Localization localizationModel)
		{
			Response response = new Response();
			response.Title = _localizationService.Localize("Add");
			var oldLocalize = await _repo.Filter<Localization>(e => e.languageId == localizationModel.languageId && e.keyName == localizationModel.keyName).FirstOrDefaultAsync();
			if (oldLocalize != null)
			{
				response.Message = _localizationService.Localize("Exsits");
				response.Status = false;
				return response;
			}
			else
			{
				var localize = await _repo.CreateAsync(localizationModel);
				await _repo.SaveChangesAsync();
				if (localize?.localizeId != null)
				{
					response.Message = _localizationService.Localize("Added");
					response.Status = true;
					return response;
				}
			}
			response.Message = _localizationService.Localize("AddedError");
			response.Status = false;
			return response;

		}
		[AuthAttribute("delete", "localization")]
		[HttpGet]
		[Route("localization/Delete/{id}")]
		public async Task<Response> Delete(int id)
		{
			Response response = new Response();
			response.Title = _localizationService.Localize("Delete");
			var localization = _repo.Filter<Localization>(e => e.localizeId == id).FirstOrDefault();
			if (localization != null)
			{
				_repo.Delete<Localization>(localization);
				await _repo.context.SaveChangesAsync();
				response.Message = _localizationService.Localize("Deleted");
				response.Status = true;
				return response;
			}
			response.Message = _localizationService.Localize("DeletedError");
			response.Status = false;
			return response;
		}
	}
}
