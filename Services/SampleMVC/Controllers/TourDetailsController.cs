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
			tourModel.additionalInformations = await _repo.Filter<AdditionalInformation>(e => e.tourId == id).ToListAsync();
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
		[Route("TourDetails/addBookRequestAndCheckOut")]
		public async Task<Response> addBookRequestAndCheckOut([FromBody] Booking bookModel)
		{
			Response response = new Response();
			response.Title = _localizationService.Localize("CheckOut");
			if (bookModel != null)
			{
				var bookRequest = await _repo.CreateAsync<Booking>(bookModel);
				await _repo.SaveChangesAsync();
				if (bookRequest.requestId != null)
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
		[HttpPost]
		[Route("TourDetails/Add")]
		public async Task<Response> Add([FromBody] Booking bookModel)
		{
			Response response = new Response();
			response.Title = _localizationService.Localize("CheckOut");
			response.Cancel = _localizationService.Localize("Cancel");
			int? maxAdultForSingleRoom = 0;
			int? maxAdultForDoubleRoom = 0;
			int? maxAdultForTripleRoom = 0;
			int? maxChildForSingleRoom = 0;
			int? maxChildForDoubleRoom = 0;
			int? maxChildForTripleRoom = 0;
			int? maxInfantForSingleRoom = 0;
			int? maxInfantForDoubleRoom = 0;
			int? maxInfantForTripleRoom = 0;
			List<HotelRoomPricing> singleRooms = _repo.GetAll<HotelRoomPricing>().ToList();
			var singleRoom = _repo.Filter<HotelRoomPricing>(e => e.hotelTypeId == bookModel.hotelTypeId && e.roomTypeId == 1).FirstOrDefault();
			var doubleRoom = _repo.Filter<HotelRoomPricing>(e => e.hotelTypeId == bookModel.hotelTypeId && e.roomTypeId == 2).FirstOrDefault();
			var trileRoom = _repo.Filter<HotelRoomPricing>(e => e.hotelTypeId == bookModel.hotelTypeId && e.roomTypeId == 3).FirstOrDefault();
			if (bookModel.numberOfSingleRoom.Value > 0)
			{
				maxAdultForSingleRoom = singleRoom?.numberOfAdult * bookModel.numberOfSingleRoom.Value;
				maxChildForSingleRoom = singleRoom?.numberOfChild * bookModel.numberOfSingleRoom.Value;
				maxInfantForSingleRoom = singleRoom?.numberOfInfant * bookModel.numberOfSingleRoom.Value;
			}
			if (bookModel.numberOfDoubleRoom.Value > 0)
			{
				maxAdultForDoubleRoom = doubleRoom?.numberOfAdult * bookModel.numberOfDoubleRoom.Value;
				maxChildForDoubleRoom = doubleRoom?.numberOfChild * bookModel.numberOfDoubleRoom.Value;
				maxInfantForDoubleRoom = doubleRoom?.numberOfInfant * bookModel.numberOfDoubleRoom.Value;
			}
			if (bookModel.numberOfTripleRoom.Value > 0)
			{
				maxAdultForTripleRoom = trileRoom?.numberOfAdult * bookModel.numberOfTripleRoom.Value;
				maxChildForTripleRoom = trileRoom?.numberOfChild * bookModel.numberOfTripleRoom.Value;
				maxInfantForTripleRoom = trileRoom?.numberOfInfant * bookModel.numberOfTripleRoom.Value;
			}
			var maxAdult = maxAdultForSingleRoom + maxAdultForDoubleRoom + maxAdultForTripleRoom;
			var maxChild = maxChildForSingleRoom + maxChildForDoubleRoom + maxChildForTripleRoom;
			var maxInfant = maxInfantForSingleRoom + maxInfantForDoubleRoom + maxInfantForTripleRoom;
			if (maxAdult < bookModel.numberOfAdult || maxChild < bookModel.numberOfChild || maxInfant < bookModel.numberOfInfant)
			{
				response.Status = false;
				response.Message = _localizationService.Localize("NumberOfSelectedRoomNotMatched");
				return response;
			}
			Tour tour = _repo.Filter<Tour>(e => e.tourId == bookModel.tourId).FirstOrDefault();
			decimal totalPrice = 0;
			decimal adultPrice = 0;
			decimal childPrice = 0;
			decimal infantPrice = 0;
			decimal singleRoomPrice = 0;
			decimal doubleRoomPrice = 0;
			decimal tripleRoomPrice = 0;
			if (tour != null)
			{
				adultPrice = tour.adultPrice.Value * bookModel.numberOfAdult.Value;
				childPrice = tour.childPrice.Value * bookModel.numberOfChild.Value;
				infantPrice = tour.infantPrice.Value * bookModel.numberOfInfant.Value;
				singleRoomPrice = bookModel.numberOfSingleRoom.Value * singleRoom.price.Value;
				doubleRoomPrice = bookModel.numberOfDoubleRoom.Value * doubleRoom.price.Value;
				tripleRoomPrice = bookModel.numberOfTripleRoom.Value * trileRoom.price.Value;
				totalPrice = adultPrice + childPrice + infantPrice + singleRoomPrice + doubleRoomPrice + tripleRoomPrice;
				response.Message = _localizationService.Localize("Calculated");
				response.Status = true;
				response.Total = totalPrice;
				return response;
			}
			response.Message = _localizationService.Localize("CalculatedError");
			response.Status = false;
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
