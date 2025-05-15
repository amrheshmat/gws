using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;
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
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Client, NoStore = false)]
        public async Task<IActionResult> Index()
        {
            List<Attachment> attachments = new List<Attachment>();

            List<Blog> blogs = await _repo.Filter<Blog>(e => e.languageId == language.languageId && e.isActive == "Y").ToListAsync();
            foreach (var blog in blogs)
            {
                List<Attachment> attachment = new List<Attachment>();
                attachment = await _repo.Filter<Attachment>(e => e.elementId == blog.blogId && e.type == "blog").ToListAsync();
                foreach (var attach in attachment)
                {
                    attachments.Add(attach);
                }
            }
            ViewBag.blogs = blogs.OrderByDescending(e => e.creationDate).Take(10);
            ViewBag.languages = _repo.GetAll<Language>().ToList();
            ViewBag.toursAttachments = attachments;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Test()
        {
            // This will simulate a server error and trigger the error handling
            throw new Exception("This is a test exception to trigger the error page.");
        }
        public IActionResult StatusCode(int code)
        {
            string message = code switch
            {
                404 => "Page not found.",
                403 => "Access denied.",
                401 => "Unauthorized access.",
                500 => "Something went wrong on the server.",
                _ => "An unexpected error occurred."
            };

            ViewData["ErrorMessage"] = message;
            ViewData["StatusCode"] = code;

            return View("Error");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            ViewData["StatusCode"] = 500;
            ViewData["ErrorMessage"] = "A server error occurred.";
            // Optionally log exceptionDetails here

            return View();
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
