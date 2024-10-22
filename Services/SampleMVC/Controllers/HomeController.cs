using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;
using Newtonsoft.Json;
using SampleMVC.Models;
using System.Diagnostics;
using TripBusiness.Ibusiness;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace SampleMVC.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private IRepository _repo;
        private readonly ILanguageService _languageService;
        private IConfiguration _config;
        private readonly IMailService mailService;
        public HomeController(IMailService mailService, IConfiguration config, ILanguageService languageService, ILocalizationService localizationService, ILogger<HomeController> logger, IRepositoryFactory repo)
       : base(languageService, localizationService)
        {
            _logger = logger;
            _repo = repo.Create("AGGRDB");
            this.mailService = mailService;
            _languageService = languageService;
            _config = config;
        }
        public async Task<IActionResult> Index()
        {
            var t = _repo.Filter<User>(e => e.mobile == "1").ToList();
            ViewData["Title"] = await Localize("users");
            var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;
            var language = _languageService.GetLanguageByCulture(currentCulture);
            List<Tour> tours = await _repo.Filter<Tour>(e => e.languageId == language.languageId && e.isActive == "Y").ToListAsync();
            List<TourAttachment> tourAttachments = new List<TourAttachment>();
            foreach (var tour in tours)
            {
                List<TourAttachment> tourAttachment = new List<TourAttachment>();
                tourAttachment = await _repo.Filter<TourAttachment>(e => e.tourId == tour.tourId && e.type=="tour").ToListAsync();
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
            List<WhyChooseUs> whyChooseUs = await _repo.Filter<WhyChooseUs>(e => e.languageId == language.languageId).ToListAsync();
            ViewBag.whyChooseUs = whyChooseUs;
            ViewBag.whyChooseUs = whyChooseUs;
            ViewBag.settings = settings;
            ViewBag.NbeJs = _config.GetSection("NbeJs").Value!.ToString(); ;
            ViewBag.tours = tours.OrderByDescending(e=> int.Parse(e.duration));
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
