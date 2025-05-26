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
    public class LoginController : BaseController
    {
        private readonly ILogger<LoginController> _logger;
        private IRepository _repo;
        private ILocalizationService _localizationService;
        private ISecurity _security;
        public LoginController(ILogger<LoginController> logger, IRepositoryFactory repo, ISecurity security, ILanguageService languageService, ILocalizationService localizationService) : base(languageService, localizationService)
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
            if (currentUser == null)
                return View();
            ViewBag.NumberOfUsers = _repo.GetAll<User>().ToList().Count();
            ViewBag.NumberOfRoles = _repo.GetAll<Role>().ToList().Count();
            ViewBag.languages = _repo.GetAll<Language>().ToList();

            return RedirectToAction("index", "Profile");
        }
        public IActionResult RegisterResult()
        {
            return View();
        }
        public async Task<IActionResult> Register()
        {
            var currentUser = HttpContext.Session.GetString("currentUser");
            ViewData["users"] = await Localize("users");
            if (currentUser == null)
            {
                try
                {
                    var categories = _repo.GetAll<Category>().ToList(); // Load from database
                    var cities = _repo.GetAll<City>().ToList(); // Load from database

                    var model = new RegisterModel
                    {
                        Categories = categories,
                        Cities = cities
                    };
                    return View(model);
                }
                catch (Exception ex) { }
            }
            ViewBag.NumberOfUsers = _repo.GetAll<User>().ToList().Count();
            ViewBag.NumberOfRoles = _repo.GetAll<Role>().ToList().Count();
            ViewBag.languages = _repo.GetAll<Language>().ToList();

            return RedirectToAction("index", "Profile");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
        [HttpPost]
        public Response subscribe(RegisterModel registerModel)
        {
            Response response = new Response();
            response.Status = false;
            response.Title = "subscribe";
            if (ModelState.IsValid)
            {
                User getOldUser = _repo.Filter<User>(e => e.userName == registerModel.userName).FirstOrDefault();
                if (getOldUser == null)
                {
                    User newUser = new User();
                    newUser.userName = registerModel.userName;
                    newUser.fullName = registerModel.fullName;
                    newUser.email = registerModel.email;
                    newUser.mobile = registerModel.mobile;
                    newUser.gender = registerModel.gender;
                    newUser.status = "P";//pending
                    newUser.password = MPSSecurity.Hash(registerModel.password);
                    newUser.creationDate = DateTime.Now;
                    var createdUser = _repo.Create<User>(newUser);
                    _repo.SaveChanges();
                    if (createdUser != null && createdUser.userId != null)
                    {
                        Subscriber subscriber = new Subscriber();
                        subscriber.userId = createdUser.userId;
                        subscriber.isVerified = "N";
                        subscriber.status = "P";//pending
                        subscriber.created_at = DateTime.Now;
                        subscriber.city = registerModel.SelectedCity;
                        var createdSubscriber = _repo.Create<Subscriber>(subscriber);
                        try
                        {
                            _repo.SaveChanges();
                        }
                        catch (Exception ex) { }
                        if (createdSubscriber != null && createdSubscriber.id != null)
                        {
                            if (registerModel.SelectedCategoryIds != null)
                            {
                                foreach (var categoryId in registerModel.SelectedCategoryIds)
                                {
                                    UserCategory userCategory = new UserCategory();
                                    userCategory.user_id = createdSubscriber.userId;
                                    userCategory.category_id = categoryId;
                                    _repo.Create<UserCategory>(userCategory);
                                    _repo.SaveChanges();
                                }
                            }
                            response.Status = true;
                            response.Message = "you register successfully , wait untill acivate use";
                        }
                    }
                }
                else
                {
                    response.Status = false;
                    response.Message = "User name already exists";
                }
            }
            return response;
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
                    return RedirectToAction("index", "Profile");
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