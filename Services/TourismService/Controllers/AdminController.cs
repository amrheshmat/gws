using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using MWS.Business.Shared;
using MWS.Business.Shared.Data.Models;
using MWS.Data.Entities;
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
		private ILocalizationService _localizationService;
		private ISecurity _security;
		public AdminController(ILogger<AdminController> logger, IRepositoryFactory repo, ISecurity security, ILanguageService languageService, ILocalizationService localizationService) : base(languageService, localizationService)
		{
			_logger = logger;
			_repo = repo.Create("AGGRDB");
			_security = security;
			_localizationService = localizationService;
		}
		public async Task<IActionResult> Index()
		{
			var currentUser = HttpContext.Session.GetString("currentUser");
			ViewData["users"] = await Localize("users");
			int successRequest = _repo.Filter<Booking>(e => e.status == "Y").ToList().Count;
			ViewBag.NumberOfRequest = _repo.GetAll<Booking>().ToList().Count();
			double NumberOfSuccessRequest = (double)successRequest / ViewBag.NumberOfRequest;
			ViewBag.NumberOfSuccessRequest = Math.Round(NumberOfSuccessRequest * 100);
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
					//var value = HttpContext.Session.GetString("currentUser");
					//UserDTO m = JsonConvert.DeserializeObject<UserDTO>(value);
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
		public async Task<IActionResult> ChangePassword()
		{

			return View();
		}
		[HttpPost]
		[Route("admin/ChangePassword")]
		public async Task<Response> ChangePassword([FromBody] ChangePasswordModel model)
		{
			Response response = new Response();
			response.Title = _localizationService.Localize("ChangePassword");
			var value = HttpContext.Session.GetString("currentUser");
			UserDTO currentUser = JsonConvert.DeserializeObject<UserDTO>(value);
			var user = _repo.Filter<User>(e => e.userName == currentUser.userName).FirstOrDefault();
			var isCorrectPassword = MPSSecurity.Verify(user.password!, model.oldPassword);
			if (!isCorrectPassword)
			{
				user.password = MPSSecurity.Hash(model.newPassword);
				var newUser = _repo.Update(user);
				await _repo.SaveChangesAsync();
				if (newUser != null)
				{
					response.Message = _localizationService.Localize("ChangePassword");
					response.Status = true;
					return response;
				}
			}
			response.Message = _localizationService.Localize("ChangePasswordError");
			response.Status = false;
			return response;
		}
	}
}