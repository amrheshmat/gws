using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MWS.Business.Shared.Data.Models;
using MWS.Data.Entities;
using MWS.Data.ViewModels;
using MWS.Infrustructure.Repositories;
using SampleMVC.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using TripBusiness.Ibusiness;

namespace SampleMVC.Controllers
{
    public class TourDetailsController : Controller
    {
        private ILocalizationService _localizationService;
        private IRepository _repo;
        private IMailService _mailService;
        public TourDetailsController(IMailService mailService, ILocalizationService localizationService, IRepositoryFactory repo)
        {
            _repo = repo.Create("AGGRDB");
            _localizationService = localizationService;
            _mailService = mailService;
        }
        [Route("TourDetails/{id}")]
        public async Task<IActionResult> index(int id)//index page
        {

            TourModel tourModel = new TourModel();
            tourModel.Tour = await _repo.Filter<Tour>(e => e.tourId == id).FirstOrDefaultAsync();
            tourModel.includes = await _repo.Filter<Include>(e => e.tourId == id).ToListAsync();
            tourModel.excludes = await _repo.Filter<Exclude>(e => e.tourId == id).ToListAsync();
            tourModel.expects = await _repo.Filter<Expect>(e => e.tourId == id).ToListAsync();
            //tourModel.packs = await _repo.Filter<Pack>(e => e.tourId == id).ToListAsync();
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
        private Booking buildBooking(BookingModel model)
        {
            Booking booking = new Booking();
            booking.requestId = model.requestId;
            booking.name = model.name;
            booking.email = model.email;
            booking.tourId = model.tourId;
            booking.status = model.status;
            booking.countryName = model.countryName;
            booking.pickup = model.pickup;
            booking.tourDate = model.tourDate;
            booking.numberOfAdult = model.numberOfAdult;
            booking.numberOfChild = model.numberOfChild;
            booking.numberOfInfant = model.numberOfInfant;
            booking.numberOfRoom = model.roomCountList?.Where(e => e.count > 0).Select(e => e.count).Sum();
            return booking;
        }
        [HttpPost]
        [Route("TourDetails/addBookRequest")]
        public async Task<Response> addBookRequest([FromBody] BookingModel bookModel)
        {
            Response response = new Response();
            response.Title = _localizationService.Localize("CheckOut");
            if (bookModel != null)
            {
                var booking = buildBooking(bookModel);
                var bookRequest = await _repo.CreateAsync<Booking>(booking);
                await _repo.SaveChangesAsync();
                SpecialRequest specialRequest = new SpecialRequest();
                if (bookRequest.requestId != null)
                {
                    response.Message = _localizationService.Localize("Added");
                    response.Status = true;
                    response.Id = bookRequest.requestId.ToString();
                    return response;
                }
            }
            response.Message = _localizationService.Localize("AddedError");
            response.Status = false;
            return response;
        }
        [HttpGet]
        [Route("TourDetails/checkOut/{id}")]
        public async Task<Response> checkOut(long id)
        {

            Response response = new Response();
            response.Title = _localizationService.Localize("CheckOut");
            decimal adultPrice = 0;
            decimal childPrice = 0;
            decimal infantPrice = 0;
            var bookRequest = await _repo.Filter<Booking>(e => e.requestId == id).FirstOrDefaultAsync();
            if (bookRequest.requestId != null)
            {
                var tour = await _repo.Filter<Tour>(e => e.tourId == bookRequest.tourId).FirstOrDefaultAsync();
                adultPrice = tour.adultPrice.Value * bookRequest.numberOfAdult.Value;
                childPrice = tour.childPrice.Value * bookRequest.numberOfChild.Value;
                infantPrice = tour.infantPrice.Value * bookRequest.numberOfInfant.Value;
                var totalPrice = adultPrice + childPrice + infantPrice;
                PaymentSessionRequest paymentSessionRequest = new PaymentSessionRequest();
                paymentSessionRequest.apiOperation = "INITIATE_CHECKOUT";
                paymentSessionRequest.interaction = new Interaction();
                paymentSessionRequest.interaction.operation = "AUTHORIZE";
                paymentSessionRequest.interaction.displayControl = new DisplayControl();
                paymentSessionRequest.interaction.displayControl.billingAddress = "OPTIONAL";
                paymentSessionRequest.interaction.displayControl.customerEmail = "OPTIONAL";
                paymentSessionRequest.interaction.displayControl.shipping = "HIDE";
                paymentSessionRequest.interaction.merchant = new Merchant();
                paymentSessionRequest.interaction.merchant.name = "Nbe Test";
                paymentSessionRequest.order = new Order();
                paymentSessionRequest.order.currency = "EGP";
                paymentSessionRequest.order.amount = totalPrice.ToString();
                paymentSessionRequest.order.id = id.ToString();
                paymentSessionRequest.order.description = "test";
                string sessionId = await createPaymentSession(paymentSessionRequest);
                response.Message = _localizationService.Localize("Added");
                response.Status = true;
                response.Id = sessionId;
                return response;
            }
            else
            {
                response.Message = _localizationService.Localize("AddedError");
                response.Status = false;
                return response;
            }
        }
        public async Task<string> createPaymentSession(PaymentSessionRequest request)
        {
            HttpClient client = new HttpClient();


            var url = "https://test-nbe.gateway.mastercard.com/api/rest/version/72/merchant/TESTEGPTEST/session";
            client.DefaultRequestHeaders.Accept.Clear();
            var byteArray = Encoding.ASCII.GetBytes("merchant.TESTEGPTEST:c622b7e9e550292df400be7d3e846476");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("text/plain"));
            HttpResponseMessage response = await client.PostAsJsonAsync(url, request);
            var result = await response.Content.ReadAsStringAsync();
            PaymentSession paymentSession = JsonSerializer.Deserialize<PaymentSession>(result)!;
            return paymentSession.session.id;
        }
        [HttpGet]
        [Route("TourDetails/updateRequestStatusAndSendEmail/{id}")]
        public async Task<Response> updateRequestStatusAndSendEmail(long id)
        {
            Response response = new Response();
            response.Title = _localizationService.Localize("CheckOut");

            var bookRequest = await _repo.Filter<Booking>(e => e.requestId == id).FirstOrDefaultAsync();
            if (bookRequest.requestId != null)
            {
                //update request ...
                bookRequest.status = "Y";
                _repo.Update(bookRequest);
                _repo.SaveChanges();
                Tour tour = _repo.Filter<Tour>(e => e.tourId == bookRequest.tourId).FirstOrDefault();
                #region email
                MailRequest mailRequest = new MailRequest();
                mailRequest.booking = bookRequest;
                mailRequest.Subject = _localizationService.Localize("BookTour");
                mailRequest.tourName = tour?.title;
                mailRequest.ToEmail = new List<string>();
                List<User> users = new List<User>();
                decimal? permissionId = _repo.Filter<Permission>(permission => permission.permissionArea.ToLower() == "request".ToLower()).FirstOrDefault().permissionId;
                if (permissionId != null)
                {
                    List<RolePermission> role = _repo.Filter<RolePermission>(e => e.permissionId == permissionId).ToList();
                    if (role != null)
                    {
                        foreach (RolePermission rolePermission in role)
                        {
                            List<User> usersForRole = new List<User>();
                            usersForRole = _repo.Filter<User>(e => e.roleId == rolePermission.roleId).ToList();
                            foreach (User user in usersForRole)
                            {
                                if (!users.Contains(user))
                                    users.Add(user);
                            }
                        }
                    }
                }
                //get mails from user table base on permission ...
                if (users != null && users.Count > 0)
                {
                    foreach (var user in users)
                    {
                        mailRequest.ToEmail?.Add(user.email);
                    }
                }
                //send email to website users that have permission contacts ...
                await _mailService.SendBookEmailAsync(mailRequest);
                //send email to client ....
                mailRequest.ToEmail = new List<string>();
                mailRequest.ToEmail?.Add(bookRequest.email);
                mailRequest.Subject = _localizationService.Localize("ThankYou");
                mailRequest.Body = _localizationService.Localize("ThanksForBookTour") + ",<p>" + _localizationService.Localize("wishHappyTour") + ".</p><p>" + _localizationService.Localize("Regards") + ",</p>";
                await _mailService.SendBookThanksEmailAsync(mailRequest);
                #endregion
                response.Message = _localizationService.Localize("Added");
                response.Status = true;
                return response;
            }
            else
            {
                response.Message = _localizationService.Localize("AddedError");
                response.Status = false;
                return response;
            }
        }
        [HttpPost]
        [Route("TourDetails/Add")]
        public async Task<Response> Add([FromBody] BookingModel bookModel)
        {
            Response response = new Response();
            response.Title = _localizationService.Localize("CheckOut");
            response.Cancel = _localizationService.Localize("Cancel");
            int? maxAdult = 0;
            int? maxChild = 0;
            int? maxInfant = 0;
            List<HotelRoomPricing> singleRooms = _repo.GetAll<HotelRoomPricing>().ToList();
            var roomLimitAndPricing = _repo.GetAll<HotelRoomPricing>().ToList();
            if (bookModel.roomCountList != null && bookModel.roomCountList.Count > 0)
            {
                var selectedRoomType = bookModel.roomCountList.Where(e => e.count > 0).ToList();
                foreach (var room in selectedRoomType)
                {
                    var t = roomLimitAndPricing.Where(e => e.roomTypeId == room.roomTypeId).FirstOrDefault();
                    maxAdult += t?.numberOfAdult * room.count;
                    maxChild += t?.numberOfChild * room.count;
                    maxInfant += t?.numberOfInfant * room.count;
                }
            }
            if (maxAdult != bookModel.numberOfAdult || maxChild != bookModel.numberOfChild || maxInfant != bookModel.numberOfInfant)
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
            var capacity = tour?.capacity;
            List<Booking> bookingList = await _repo.Filter<Booking>(e => e.tourId == tour.tourId && e.tourDate == bookModel.tourDate).ToListAsync();
            var selectecCapcity = 0;
            foreach (var book in bookingList)
            {
                selectecCapcity += book.numberOfRoom.Value;
            }
            var remainingRoom = capacity - selectecCapcity;
            if (bookModel.roomCountList.Where(e => e.count > 0).Select(e => e.count).Sum() > remainingRoom)
            {
                response.Message = _localizationService.Localize("exceededCapcity");
                response.Status = false;
                return response;
            }
            if (tour != null)
            {
                adultPrice = tour.adultPrice.Value * bookModel.numberOfAdult.Value;
                childPrice = tour.childPrice.Value * bookModel.numberOfChild.Value;
                infantPrice = tour.infantPrice.Value * bookModel.numberOfInfant.Value;
                totalPrice = adultPrice + childPrice + infantPrice;
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
