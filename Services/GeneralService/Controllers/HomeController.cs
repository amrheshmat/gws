using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;
using SampleMVC.Models;
using System.Diagnostics;
using TripBusiness.Ibusiness;

namespace SampleMVC.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private IRepository _repo;
        private readonly ILanguageService _languageService;
        private readonly IMailService mailService;
        public HomeController(IMailService mailService, ILanguageService languageService, ILocalizationService localizationService, ILogger<HomeController> logger, IRepositoryFactory repo)
       : base(languageService, localizationService)
        {
            _logger = logger;
            _repo = repo.Create("AGGRDB");
            this.mailService = mailService;
            _languageService = languageService;
        }
        public async Task<IActionResult> Index()
        {

            ViewBag.languages = _repo.GetAll<Language>().ToList();
            return View();
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
