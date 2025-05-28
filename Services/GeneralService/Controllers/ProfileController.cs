using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MWS.Business.Shared.Data.Models;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;
using Newtonsoft.Json;
using SampleMVC.Controllers;
using SampleMVC.Models;
using TripBusiness.Ibusiness;

namespace GeneralService.Controllers
{
    public class ProfileController : BaseController
    {
        private readonly ILogger<ProfileController> _logger;
        private IRepository _repo;
        private ILocalizationService _localizationService;
        private ISecurity _security;
        public ProfileController(ILogger<ProfileController> logger, IRepositoryFactory repo, ISecurity security, ILanguageService languageService, ILocalizationService localizationService) : base(languageService, localizationService)
        {
            _logger = logger;
            _repo = repo.Create("AGGRDB");
            _security = security;
            _localizationService = localizationService;
        }
        public async Task<IActionResult> Index()
        {
            var currentUser = HttpContext.Session.GetString("currentUser");
            UserDTO currentUserModel = JsonConvert.DeserializeObject<UserDTO>(currentUser);
            ViewData["users"] = await Localize("users");
            if (currentUser == null)
                return RedirectToAction("Index", "Login");
            ViewBag.NumberOfUsers = _repo.GetAll<User>().ToList().Count();
            ViewBag.NumberOfRoles = _repo.GetAll<Role>().ToList().Count();
            ViewBag.languages = _repo.GetAll<Language>().ToList();
            var user = _repo.Filter<User>(e => e.userName == currentUserModel.userName).FirstOrDefault();
            var subscriber = _repo.Filter<Subscriber>(e => e.userId == user!.userId).FirstOrDefault();
            var categories = _repo.GetAll<Category>().ToList(); // Load from database
            var cities = _repo.GetAll<City>().ToList(); // Load from database
            var subscriberCategory = _repo.Filter<UserCategory>(e => e.user_id == user!.userId).ToList();
            List<string> categoriesList = new List<string>();
            foreach (var category in subscriberCategory)
            {
                string categoryName = categories.Where(e => e.id == category.id).FirstOrDefault().id.ToString();
                categoriesList.Add(categoryName);
            }
            var model = new ProfileModel
            {
                basicInfo = new BasicInfoModel
                {
                    FullName = user!.fullName,
                    Email = user.email,
                    Phone = user.mobile,
                    City = subscriber.city,
                    SelectedCategories = categoriesList,
                    AvailableCategories = categories.Select(c => new SelectListItem
                    {
                        Value = c.id.ToString(),
                        Text = c.name
                    }).ToList(),
                    Cities = cities
                }
            };

            return View(model);
        }
    }
}
