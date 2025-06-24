using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MWS.Business.Shared.Data.Models;
using MWS.Data.Entities;
using MWS.Data.ViewModels;
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
        string GetFirstWords(string input, int wordCount = 20)
        {
            if (string.IsNullOrWhiteSpace(input))
                return "";

            var words = input.Split(new[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            return string.Join(" ", words.Take(wordCount)) + (words.Length > wordCount ? "..." : "");
        }
        public async Task<IActionResult> Index()
        {
            HomeModel homeModel = new HomeModel();
            var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;
            var language = _languageService.GetLanguageByCulture(currentCulture);
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
                blog.description = GetFirstWords(blog.description, 20);
            }
            List<City> cities = _repo.GetAll<City>().ToList();
            List<Category> categories = _repo.GetAll<Category>().ToList();
            ViewBag.cities = cities;
            ViewBag.categories = categories;
            ViewBag.blogs = blogs.OrderByDescending(e => e.creationDate).Take(10);
            ViewBag.languages = _repo.GetAll<Language>().ToList();
            SearchModel searchModel = new SearchModel();
            searchModel.category = "";
            searchModel.fullName = "";
            searchModel.city = "";
            searchModel.gender = "";
            homeModel.searchModel = searchModel;
            return View(homeModel);
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
        [HttpPost]
        public async Task<Response> HomeSearch([FromForm] HomeModel homeModel)
        {
            SearchModel searchModel = homeModel.searchModel;
            Response response = new Response();
            response.Status = false;
            try
            {
                if (searchModel != null && (searchModel.fullName != null || searchModel.city != null || searchModel.category != null))
                {
                    List<User> users = null;
                    List<Subscriber> subscribers = _repo.GetAll<Subscriber>().ToList();
                    List<UserCategory> userCategory = null;
                    if (searchModel.category != null)
                    {
                        userCategory = _repo.Filter<UserCategory>(x => x.category_id == int.Parse(searchModel.category)).ToList();
                    }
                    if (searchModel != null && searchModel.fullName != null)
                    {
                        users = _repo.Filter<User>(x => x.fullName == searchModel.fullName || x.userName == searchModel.fullName).ToList();
                    }
                    if (users != null && users.Count > 0)
                    {
                        var usersId = users.Select(x => x.userId).ToList();
                        subscribers = _repo.Filter<Subscriber>(e => usersId.Contains(e.userId)).ToList();
                    }
                    if (userCategory != null && userCategory.Count > 0)
                    {
                        var usersId = userCategory.Select(x => x.user_id).ToList();
                        subscribers = _repo.Filter<Subscriber>(e => usersId.Contains(e.userId)).ToList();
                    }
                    if (searchModel != null && searchModel.city != null)
                    {
                        subscribers = subscribers.Where(x => x.city == searchModel.city).ToList();
                    }
                    response.Status = true;
                    ViewBag.subscribers = subscribers;
                }
                else
                {
                    response.Status = false;
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "an error occurred";
            }
            return response;
        }

    }
}
