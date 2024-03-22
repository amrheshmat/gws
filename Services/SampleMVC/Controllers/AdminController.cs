using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using MWS.Business.Shared;
using MWS.Business.Shared.Data.Models;
using MWS.Infrustructure.Repositories;
using Newtonsoft.Json;
using SampleMVC.Models;
using TripBusiness.Ibusiness;

namespace SampleMVC.Controllers
{
    public class AdminController : BaseController
    {
        private readonly ILogger<AdminController> _logger;
        private IRepository _repo;
        private ISecurity _security;
        public AdminController(ILogger<AdminController> logger, IRepositoryFactory repo, ISecurity security, ILanguageService languageService, ILocalizationService localizationService) : base(languageService, localizationService)
        {
            _logger = logger;
            _repo = repo.Create("AGGRDB");
            _security = security;
        }
        public async Task<IActionResult> Index()
        {
            var currentUser = HttpContext.Session.GetString("currentUser");
            ViewData["users"] = await Localize("users");
            if (currentUser == null)
                return RedirectToAction("Login", "admin");
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [AuthAttribute("index", "home")]
        public IActionResult Test()
        {
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var user = await _security.CreateToken(loginModel.userName, loginModel.password);
            if (user != "404")
            {
                var t = (UserDTO)user;
                if (t != null)
                {
                    HttpContext.Session.SetString("currentUser", JsonConvert.SerializeObject(t));
                    var value = HttpContext.Session.GetString("currentUser");
                    UserDTO m = JsonConvert.DeserializeObject<UserDTO>(value);
                    return RedirectToAction("index", "admin");

                }
            }
            else
            {
                return RedirectToAction("AccessDenied", "admin");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
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
    }
}