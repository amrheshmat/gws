using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MWS.Business.Shared;
using MWS.Business.Shared.Data.Models;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;
using TripBusiness.Ibusiness;

namespace SampleMVC.Controllers
{
	public class LanguageController : Controller
	{
		private ILocalizationService _localizationService;
		private IRepository _repo;
		public LanguageController(ILocalizationService localizationService, IRepositoryFactory repo)
		{
			_repo = repo.Create("AGGRDB");
			_localizationService = localizationService;
		}
		[AuthAttribute("language", "language")]
		public async Task<IActionResult> Language()//index page
		{
			List<Language> languages = await _repo.GetAll<Language>().ToListAsync();
			ViewBag.languages = languages;
			return View();

		}
		[AuthAttribute("add", "language")]
		[HttpPost]
		[Route("language/add")]
		public async Task<Response> Add([FromBody] Language languageModel)
		{
			Response response = new Response();
			response.Title = _localizationService.Localize("Add");
			var Language = await _repo.CreateAsync<Language>(languageModel);
			await _repo.SaveChangesAsync();
			if (Language != null)
			{
				response.Message = _localizationService.Localize("Added");
				response.Status = true;
				return response;
			}
			response.Message = _localizationService.Localize("AddedError");
			response.Status = false;
			return response;
		}
		[AuthAttribute("edit", "language")]
		[HttpPost]
		[Route("language/Edit")]
		public async Task<Response> Edit([FromBody] Language languageModel)
		{
			Response response = new Response();
			response.Title = _localizationService.Localize("Update");
			var Language = _repo.Update<Language>(languageModel);
			_repo.SaveChanges();
			if (Language != null)
			{
				response.Message = _localizationService.Localize("Updated");
				response.Status = true;
				return response;
			}
			response.Message = _localizationService.Localize("UpdatedError");
			response.Status = false;
			return response;
		}
		[AuthAttribute("delete", "language")]
		[HttpGet]
		[Route("language/Delete/{id}")]
		public async Task<Response> Delete(int id)
		{
			Response response = new Response();
			response.Title = _localizationService.Localize("Delete");
			var language = _repo.Filter<Language>(e => e.languageId == id).FirstOrDefault();
			if (language != null)
			{
				_repo.Delete<Language>(language);
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
