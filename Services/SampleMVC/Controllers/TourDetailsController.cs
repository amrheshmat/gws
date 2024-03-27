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
        public async Task<Response> Add([FromBody] Booking bookModel)
        {
            Response response = new Response();
            int? maxAdultForSingleRoom = 0;
            int? maxAdultForDoubleRoom = 0;
            int? maxAdultForTripleRoom = 0;
            int? maxChildForSingleRoom = 0;
            int? maxChildForDoubleRoom = 0;
            int? maxChildForTripleRoom = 0;
            int? maxInfantForSingleRoom = 0;
            int? maxInfantForDoubleRoom = 0;
            int? maxInfantForTripleRoom = 0;
            if (bookModel.numberOfSingleRoom.Value > 0)
            {
                maxAdultForSingleRoom = _repo.Filter<HotelRoomPricing>(e => e.hotelTypeId == bookModel.hotelTypeId && e.roomTypeId == 1).FirstOrDefault()?.numberOfAdult * bookModel.numberOfSingleRoom.Value;
                maxChildForSingleRoom = _repo.Filter<HotelRoomPricing>(e => e.hotelTypeId == bookModel.hotelTypeId && e.roomTypeId == 1).FirstOrDefault()?.numberOfChild * bookModel.numberOfSingleRoom.Value;
                maxInfantForSingleRoom = _repo.Filter<HotelRoomPricing>(e => e.hotelTypeId == bookModel.hotelTypeId && e.roomTypeId == 1).FirstOrDefault()?.numberOfInfant * bookModel.numberOfSingleRoom.Value;
            }
            if (bookModel.numberOfDoubleRoom.Value > 0)
            {
                maxAdultForDoubleRoom = _repo.Filter<HotelRoomPricing>(e => e.hotelTypeId == bookModel.hotelTypeId && e.roomTypeId == 2).FirstOrDefault()?.numberOfAdult * bookModel.numberOfDoubleRoom.Value;
                maxChildForDoubleRoom = _repo.Filter<HotelRoomPricing>(e => e.hotelTypeId == bookModel.hotelTypeId && e.roomTypeId == 2).FirstOrDefault()?.numberOfChild * bookModel.numberOfDoubleRoom.Value;
                maxInfantForDoubleRoom = _repo.Filter<HotelRoomPricing>(e => e.hotelTypeId == bookModel.hotelTypeId && e.roomTypeId == 2).FirstOrDefault()?.numberOfInfant * bookModel.numberOfDoubleRoom.Value;
            }
            if (bookModel.numberOfTripleRoom.Value > 0)
            {
                maxAdultForTripleRoom = _repo.Filter<HotelRoomPricing>(e => e.hotelTypeId == bookModel.hotelTypeId && e.roomTypeId == 3).FirstOrDefault()?.numberOfAdult * bookModel.numberOfTripleRoom.Value;
                maxChildForTripleRoom = _repo.Filter<HotelRoomPricing>(e => e.hotelTypeId == bookModel.hotelTypeId && e.roomTypeId == 3).FirstOrDefault()?.numberOfChild * bookModel.numberOfTripleRoom.Value;
                maxInfantForTripleRoom = _repo.Filter<HotelRoomPricing>(e => e.hotelTypeId == bookModel.hotelTypeId && e.roomTypeId == 3).FirstOrDefault()?.numberOfInfant * bookModel.numberOfTripleRoom.Value;
            }
            var maxAdult = maxAdultForSingleRoom + maxAdultForDoubleRoom + maxAdultForTripleRoom;
            var maxChild = maxChildForSingleRoom + maxChildForDoubleRoom + maxChildForTripleRoom;
            var maxInfant = maxInfantForSingleRoom + maxInfantForDoubleRoom + maxInfantForTripleRoom;
            if (maxAdult < bookModel.numberOfAdult && (maxAdult + maxChild + maxInfant < bookModel.numberOfAdult + bookModel.numberOfChild + bookModel.numberOfInfant))
            {
                response.Status = false;
            }
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
