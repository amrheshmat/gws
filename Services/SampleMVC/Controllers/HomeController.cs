using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;
using Newtonsoft.Json;
using SampleMVC.Models;
using System.Diagnostics;
using TripBusiness.Ibusiness;

namespace SampleMVC.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private IRepository _repo;
        private readonly IMailService mailService;
        public HomeController(IMailService mailService, ILanguageService languageService, ILocalizationService localizationService, ILogger<HomeController> logger, IRepositoryFactory repo)
       : base(languageService, localizationService)
        {
            _logger = logger;
            _repo = repo.Create("AGGRDB");
            this.mailService = mailService;
        }
        public async Task<IActionResult> Index()
        {
            var t = _repo.Filter<User>(e => e.mobile == "1").ToList();
            ViewData["Title"] = await Localize("users");
            List<Tour> tours = await _repo.GetAll<Tour>().ToListAsync();
            List<TourAttachment> tourAttachments = new List<TourAttachment>();
            foreach (var tour in tours)
            {
                List<TourAttachment> tourAttachment = new List<TourAttachment>();
                tourAttachment = await _repo.Filter<TourAttachment>(e => e.tourId == tour.tourId).ToListAsync();
                foreach (var attachment in tourAttachment)
                {
                    tourAttachments.Add(attachment);
                }
            }
            List<Setting> settings = await _repo.GetAll<Setting>().ToListAsync();
            foreach (var setting in settings)
            {
                HttpContext.Session.SetString(setting.keyName, JsonConvert.SerializeObject(setting.value));
            }
            ViewBag.settings = settings;
            ViewBag.tours = tours;
            ViewBag.toursAttachments = tourAttachments;
            return View(tourAttachments);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public IActionResult ChangeLanguage(string culture, string returnUrl)

        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddDays(7)
                }
            );

            return LocalRedirect(returnUrl);
        }
        [HttpPost("Send")]
        public async Task<IActionResult> Send([FromForm] MailRequest request)
        {
            try
            {
                await mailService.SendContactEmailAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
