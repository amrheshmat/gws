using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MWS.Business.Shared;
using MWS.Business.Shared.Data.Models;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;
using TripBusiness.Ibusiness;

namespace SampleMVC.Controllers
{
	public class ActivityController : Controller
	{
		private ILocalizationService _localizationService;
		private IRepository _repo;
		public ActivityController(ILocalizationService localizationService, IRepositoryFactory repo)
		{
			_repo = repo.Create("AGGRDB");
			_localizationService = localizationService;
		}
		[AuthAttribute("activity", "activity")]
		public async Task<IActionResult> Activity()//index page
		{
			List<AdditionalActivity> activitys = await _repo.GetAll<AdditionalActivity>().ToListAsync();
			ViewBag.activitys = activitys;
			return View();

		}
		[AuthAttribute("add", "activity")]
		[HttpPost]
		[Route("activity/add")]
		public async Task<Response> Add([FromBody] AdditionalActivity activityModel)
		{
			Response response = new Response();
			response.Title = _localizationService.Localize("Add");
			var Activity = await _repo.CreateAsync<AdditionalActivity>(activityModel);
			await _repo.SaveChangesAsync();
			if (Activity != null)
			{
				response.Message = _localizationService.Localize("Added");
				response.Status = true;
				return response;
			}
			response.Message = _localizationService.Localize("AddedError");
			response.Status = false;
			return response;
		}
		[AuthAttribute("edit", "activity")]
		[HttpPost]
		[Route("activity/Edit")]
		public async Task<Response> Edit([FromBody] AdditionalActivity activityModel)
		{
			Response response = new Response();
			response.Title = _localizationService.Localize("Update");
			var Activity = _repo.Update<AdditionalActivity>(activityModel);
			_repo.SaveChanges();
			if (Activity != null)
			{
				response.Message = _localizationService.Localize("Updated");
				response.Status = true;
				return response;
			}
			response.Message = _localizationService.Localize("UpdatedError");
			response.Status = false;
			return response;
		}
		[AuthAttribute("delete", "activity")]
		[HttpGet]
		[Route("activity/Delete/{id}")]
		public async Task<Response> Delete(int id)
		{
			Response response = new Response();
			response.Title = _localizationService.Localize("Delete");
			var activity = _repo.Filter<AdditionalActivity>(e => e.additionalActivityId == id).FirstOrDefault();
			if (activity != null)
			{
				_repo.Delete<AdditionalActivity>(activity);
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
