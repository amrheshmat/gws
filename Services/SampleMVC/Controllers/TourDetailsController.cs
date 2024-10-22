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
        private IConfiguration _config;

        public TourDetailsController(IMailService mailService, IConfiguration config, ILocalizationService localizationService, IRepositoryFactory repo)
        {
            _repo = repo.Create("AGGRDB");
            _localizationService = localizationService;
            _mailService = mailService;
            _config = config;
        }
        [Route("TourDetails/{id}")]
        public async Task<IActionResult> index(int id)//index page
        {

            TourModel tourModel = new TourModel();
            tourModel.Tour = await _repo.Filter<Tour>(e => e.tourId == id).FirstOrDefaultAsync();
            tourModel.includes = await _repo.Filter<Include>(e => e.tourId == id).ToListAsync();
            tourModel.excludes = await _repo.Filter<Exclude>(e => e.tourId == id).ToListAsync();
            tourModel.expects = await _repo.Filter<Expect>(e => e.tourId == id).ToListAsync();
            tourModel.expects = tourModel.expects.OrderBy(e => e.order).ToList();
            tourModel.blockedDates = await _repo.Filter<BlockedDates>(e => e.tourId == id).ToListAsync();
            //tourModel.packs = await _repo.Filter<Pack>(e => e.tourId == id).ToListAsync();
            tourModel.additionalInformations = await _repo.Filter<AdditionalInformation>(e => e.tourId == id).ToListAsync();
            tourModel.tourDays = await _repo.Filter<TourDay>(e => e.tourId == id).ToListAsync();
            tourModel.tourLanguages = await _repo.Filter<TourLanguage>(e => e.tourId == id).ToListAsync();
            List<Day> days = await _repo.GetAll<Day>().ToListAsync();
            //List<Language> languages = await _repo.GetAll<Language>().ToListAsync();
            List<TourAttachment> attachments = await _repo.Filter<TourAttachment>(e => e.tourId == id && e.type =="tour").ToListAsync();
            List<HotelType> hotels = await _repo.GetAll<HotelType>().ToListAsync();
            List<RoomType> rooms = await _repo.GetAll<RoomType>().ToListAsync();
            ViewBag.days = days;
            ViewBag.languages = tourModel.tourLanguages;
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
            booking.totalPrice = model.totalPrice;
            booking.email = model.email;
            booking.phone = model.phone;
            booking.tourId = model.tourId;
            booking.status = model.status;
            booking.countryName = model.countryName;
            booking.languageName = model.languageName;
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
                List<BookAdditionalActivity> additionalActivities = new List<BookAdditionalActivity>();
                decimal additionalPrice = 0;
                if (bookRequest.requestId != null)
                {
                    if (bookModel.bookAdditionalActivities != null && bookModel.bookAdditionalActivities.Count > 0)
                    {
                        var distinctActivities = bookModel.bookAdditionalActivities.Select(e => e.tourActivityId).Distinct().ToList();
                        foreach (var activity in distinctActivities)
                        {
                            BookAdditionalActivity bookAdditionalActivity = new BookAdditionalActivity();
                            additionalPrice += _repo.Filter<AdditionalActivity>(e => e.additionalActivityId == activity).FirstOrDefault().adultPrice.Value;
                            bookAdditionalActivity.bookId = bookRequest.requestId;
                            bookAdditionalActivity.tourActivityId = activity;
                            additionalActivities.Add(bookAdditionalActivity);
                        }
                        await _repo.context.AddRangeAsync(additionalActivities);
                        await _repo.SaveChangesAsync();
                    }
                    additionalPrice = additionalPrice * bookRequest.numberOfAdult.Value;
                    bookModel.totalPrice += additionalPrice;
                    bookRequest.totalPrice = bookModel.totalPrice;
                    _repo.Update<Booking>(bookRequest);
                    await _repo.SaveChangesAsync();
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
               var NbeCurrency = _config.GetSection("NbeCurrency").Value!.ToString();
               var NbeMerchantName = _config.GetSection("NbeMerchantName").Value!.ToString();
                var tour = await _repo.Filter<Tour>(e => e.tourId == bookRequest.tourId).FirstOrDefaultAsync();
                adultPrice = tour.adultPrice.Value * bookRequest.numberOfAdult.Value;
                childPrice = tour.childPrice.Value * bookRequest.numberOfChild.Value;
                infantPrice = tour.infantPrice.Value * bookRequest.numberOfInfant.Value;
                var totalPrice = adultPrice + childPrice + infantPrice;
                PaymentSessionRequest paymentSessionRequest = new PaymentSessionRequest();
                paymentSessionRequest.apiOperation = "INITIATE_CHECKOUT";
                paymentSessionRequest.interaction = new Interaction();
                paymentSessionRequest.interaction.operation = "PURCHASE";
                paymentSessionRequest.interaction.displayControl = new DisplayControl();
                paymentSessionRequest.interaction.displayControl.billingAddress = "OPTIONAL";
                paymentSessionRequest.interaction.displayControl.customerEmail = "OPTIONAL";
                paymentSessionRequest.interaction.displayControl.shipping = "HIDE";
                paymentSessionRequest.interaction.merchant = new Merchant();
                paymentSessionRequest.interaction.merchant.name = NbeMerchantName;
                paymentSessionRequest.order = new Order();
                paymentSessionRequest.order.currency = NbeCurrency;
                paymentSessionRequest.order.amount = bookRequest.totalPrice.ToString();
                paymentSessionRequest.order.id = id.ToString();
                paymentSessionRequest.order.description = "enjoy your tour";
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

            var url = _config.GetSection("NbeApi").Value!.ToString();
            var user = _config.GetSection("NbeUser").Value!.ToString();
            var pass = _config.GetSection("NbePassword").Value!.ToString();
            client.DefaultRequestHeaders.Accept.Clear();
            var byteArray = Encoding.ASCII.GetBytes(user + ":" + pass);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("text/plain"));
            HttpResponseMessage response = await client.PostAsJsonAsync(url, request);
            var result = await response.Content.ReadAsStringAsync();
            PaymentSession paymentSession = JsonSerializer.Deserialize<PaymentSession>(result)!;
            return paymentSession.session.id;
        }
        [HttpGet]
        [Route("TourDetails/updateRequestStatusAndSendEmail/{id}/{sessionId}/{status}/{errorDesc}")]
        public async Task<Response> updateRequestStatusAndSendEmail(long id,string sessionId,string status,string errorDesc)
        {
            Response response = new Response();
            response.Title = _localizationService.Localize("CheckOut");

            var bookRequest = await _repo.Filter<Booking>(e => e.requestId == id).FirstOrDefaultAsync();
            if (bookRequest.requestId != null)
            {
                //update request ...
                bookRequest.status = status;
                bookRequest.sessionReference = sessionId;
                bookRequest.paymentErrorDesc = errorDesc;
                _repo.Update(bookRequest);
                _repo.SaveChanges();
                #region email
                if (status == "complete")
                {
                    Tour tour = _repo.Filter<Tour>(e => e.tourId == bookRequest.tourId).FirstOrDefault();
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
                }
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
            if (maxAdult != bookModel.numberOfAdult || maxChild != bookModel.numberOfChild)
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
            List<Booking> bookingList2 = await _repo.GetAll<Booking>().ToListAsync();

            List<Booking> bookingList = await _repo.Filter<Booking>(e => e.tourId == tour.tourId && e.tourDate == bookModel.tourDate && e.status =="Y").ToListAsync();
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
                var selectedRoomType = bookModel.roomCountList.Where(e => e.count > 0).ToList();
                foreach (var room in selectedRoomType)
                {
                    if (room.roomTypeId == 1 || room.roomTypeId == 2)//single
                    {
                        var t = roomLimitAndPricing.Where(e => e.roomTypeId == room.roomTypeId).FirstOrDefault();
                        var adultforsingle = t?.numberOfAdult * room.count;
                        bookModel.numberOfAdult = bookModel.numberOfAdult.Value - adultforsingle.Value;
                        adultPrice += tour.adultPrice.Value * adultforsingle.Value;
                    }
                    if (bookModel.numberOfAdult.Value > 0)
                    {
                        if (room.roomTypeId == 3 || room.roomTypeId == 4)//double
                        {
                            var t = roomLimitAndPricing.Where(e => e.roomTypeId == room.roomTypeId).FirstOrDefault();
                            var adultfordouble = t?.numberOfAdult * room.count;
                            if (t?.numberOfAdult < bookModel.numberOfAdult)
                            {
                                bookModel.numberOfAdult = bookModel.numberOfAdult.Value - adultfordouble.Value;
                                adultPrice += tour.adultPriceForDouble.Value * adultfordouble.Value;
                            }
                            else
                            {
                                adultPrice += tour.adultPriceForDouble.Value * bookModel.numberOfAdult.Value;
                            }
                        }
                    }
                    if (bookModel.numberOfAdult.Value > 0)
                    {
                        if (room.roomTypeId == 5 || room.roomTypeId == 6)//suite
                        {
                            var t = roomLimitAndPricing.Where(e => e.roomTypeId == room.roomTypeId).FirstOrDefault();
                            var adultforsuite = t?.numberOfAdult * room.count;
                            if (t?.numberOfAdult < bookModel.numberOfAdult)
                            {
                                bookModel.numberOfAdult = bookModel.numberOfAdult.Value - adultforsuite.Value;
                                adultPrice += tour.adultPriceForDouble.Value * adultforsuite.Value;
                            }
                            else
                            {
                                adultPrice += tour.adultPriceForSuite.Value * bookModel.numberOfAdult.Value;
                            }
                        }
                    }

                }
                var tourActivities = await _repo.Filter<TourAdditionalActivity>(e => e.tourId == tour.tourId).ToListAsync();
                List<AdditionalActivity> additionalActivities = new List<AdditionalActivity>();
                foreach (var activity in tourActivities)
                {
                    AdditionalActivity additionalActivity = new AdditionalActivity();
                    additionalActivity = await _repo.Filter<AdditionalActivity>(e => e.additionalActivityId == activity.activityId).FirstOrDefaultAsync();
                    additionalActivities.Add(additionalActivity);
                }
                childPrice = tour.childPrice.Value * bookModel.numberOfChild.Value;
                infantPrice = tour.infantPrice.Value * bookModel.numberOfInfant.Value;
                totalPrice = adultPrice + childPrice + infantPrice;
                response.Message = _localizationService.Localize("Calculated");
                response.Status = true;
                response.Total = totalPrice;
                response.SubTitle = _localizationService.Localize("SelectAdditionalActivities");
                response.Activities = additionalActivities;
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
