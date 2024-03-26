using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MWS.Business.Shared.Data.Models;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;
using SampleMVC.Models;
using TripBusiness.Ibusiness;

namespace SampleMVC.Controllers
{
	public class TourDetailsController : Controller
	{
		private ILocalizationService _localizationService;
		private IRepository _repo;
		public TourDetailsController(ILocalizationService localizationService, IRepositoryFactory repo)
		{
			_repo = repo.Create("AGGRDB");
			_localizationService = localizationService;
		}
		[Route("TourDetails/{id}")]
		public async Task<IActionResult> index(int id)//index page
		{

			TourModel tourModel = new TourModel();
			tourModel.Tour = await _repo.Filter<Tour>(e => e.tourId == id).FirstOrDefaultAsync();
			tourModel.includes = await _repo.Filter<Include>(e => e.tourId == id).ToListAsync();
			tourModel.excludes = await _repo.Filter<Exclude>(e => e.tourId == id).ToListAsync();
			tourModel.expects = await _repo.Filter<Expect>(e => e.tourId == id).ToListAsync();
			tourModel.packs = await _repo.Filter<Pack>(e => e.tourId == id).ToListAsync();
			tourModel.tourDays = await _repo.Filter<TourDay>(e => e.tourId == id).ToListAsync();
			List<Day> days = await _repo.GetAll<Day>().ToListAsync();
			List<TourAttachment> attachments = await _repo.Filter<TourAttachment>(e => e.tourId == id).ToListAsync();
			List<HotelType> hotels = await _repo.GetAll<HotelType>().ToListAsync();
			List<RoomType> rooms = await _repo.GetAll<RoomType>().ToListAsync();
			ViewBag.days = days;
			ViewBag.attachments = attachments;
			ViewBag.hotels = hotels;
			ViewBag.rooms = rooms;
			ViewBag.currentId = id;
			return View(tourModel);

		}
		[HttpPost]
		[Route("TourDetails/Add")]
		public async Task<Response> Add([FromBody] Request userModel)
		{
			Response response = new Response();
			response.Title = _localizationService.Localize("Update");
			response.Status = true;
			return response;

		}
		[HttpPost]
		public async Task<IActionResult> Edit(Tour tourModel)
		{
			var rolePermissions = _repo.Filter<Tour>(e => e.tourId == tourModel.tourId).ToList();
			var Tour = _repo.Update<Tour>(tourModel);
			_repo.SaveChanges();
			if (Tour != null)
			{
				return RedirectToAction("Tour");
			}
			return RedirectToAction("Tour");
		}
	}
}
