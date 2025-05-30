using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MWS.Business.Shared;
using MWS.Business.Shared.Data.Models;
using MWS.Data.Entities;
using MWS.Data.Entities.anoush;
using MWS.Infrustructure.Repositories;
using SampleMVC.Models;
using TripBusiness.Ibusiness;

namespace SampleMVC.Controllers
{
    public class PricingController : BaseController
	{
		private readonly ILogger<PricingController> _logger;
		private IRepository _repo;
		private readonly IMailService mailService;
		private ILocalizationService _localizationService;

		public PricingController(IMailService mailService, ILanguageService languageService, ILocalizationService localizationService, ILogger<PricingController> logger, IRepositoryFactory repo)
	   : base(languageService, localizationService)
		{
			_logger = logger;
			_repo = repo.Create("AGGRDB");
			this.mailService = mailService;
			_localizationService = localizationService;
		}
		[AuthAttribute("pricing", "pricing")]
		public async Task<IActionResult> pricing()
		{
			List<HotelRoomPricing> hotelRoomPricings = new List<HotelRoomPricing>();
			hotelRoomPricings = await _repo.GetAll<HotelRoomPricing>().ToListAsync();
			List<TourPricingModel> model = new List<TourPricingModel>();
			foreach (var pricing in hotelRoomPricings)
			{
				TourPricingModel tourPricingModel = new TourPricingModel();
				var room = _repo.Filter<RoomType>(e => e.roomTypeId == pricing.roomTypeId).FirstOrDefault();
				//var hotel = _repo.Filter<HotelType>(e => e.hotelTypeId == pricing.hotelTypeId).FirstOrDefault();
				//tourPricingModel.hotelTypeId = hotel?.hotelTypeId;
				//tourPricingModel.hotelTypeName = hotel?.hotelTypeName;
				tourPricingModel.roomTypeId = room?.roomTypeId;
				tourPricingModel.roomTypeName = room?.roomTypeName;
				tourPricingModel.hotelRoomId = pricing.hotelRoomId;
				//tourPricingModel.price = double.Parse(pricing.price.ToString());
				tourPricingModel.numberOfAdult = pricing.numberOfAdult;
				tourPricingModel.numberOfChild = pricing.numberOfChild;
				tourPricingModel.numberOfInfant = pricing.numberOfInfant;
				model.Add(tourPricingModel);
			}
			List<HotelType> hotels = await _repo.GetAll<HotelType>().ToListAsync();
			List<RoomType> rooms = await _repo.GetAll<RoomType>().ToListAsync();
			ViewBag.pricing = model;
			ViewBag.hotels = hotels;
			ViewBag.rooms = rooms;
			return View();
		}
		[AuthAttribute("edit", "pricing")]
		[HttpPost]
		[Route("Pricing/Edit")]
		public async Task<Response> Edit([FromBody] HotelRoomPricing pricingModel)
		{
			Response response = new Response();
			response.Title = _localizationService.Localize("Update");
			var oldPricing = _repo.Filter<HotelRoomPricing>(e => e.hotelRoomId == pricingModel.hotelRoomId).FirstOrDefault();
			if (oldPricing != null)
			{
				var user = _repo.context.Update(pricingModel);
				await _repo.context.SaveChangesAsync();
				response.Message = _localizationService.Localize("Updated");
				response.Status = true;
				return response;
			}
			response.Message = _localizationService.Localize("UpdatedError");
			response.Status = false;
			return response;
		}
		[AuthAttribute("add", "pricing")]
		[HttpPost]
		[Route("Pricing/Add")]
		public async Task<Response> Add([FromBody] HotelRoomPricing pricingModel)
		{
			Response response = new Response();
			response.Title = _localizationService.Localize("Add");
			var pricing = _repo.context.Add(pricingModel);
			await _repo.context.SaveChangesAsync();
			if (pricing != null)
			{
				response.Message = _localizationService.Localize("Added");
				response.Status = true;
				return response;
			}
			response.Message = _localizationService.Localize("AddedError");
			response.Status = false;
			return response;
		}
		[AuthAttribute("delete", "pricing")]
		[HttpGet]
		[Route("Pricing/Delete/{id}")]
		public async Task<Response> Delete(int id)
		{
			Response response = new Response();
			response.Title = _localizationService.Localize("Delete");
			var hotelRoomPricing = _repo.Filter<HotelRoomPricing>(e => e.hotelRoomId == id).FirstOrDefault();
			if (hotelRoomPricing != null)
			{
				_repo.Delete<HotelRoomPricing>(hotelRoomPricing);
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
