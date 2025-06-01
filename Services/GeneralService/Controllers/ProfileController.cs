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
            var userPacakges = _repo.Filter<Package>(e => e.user_id == user!.userId).ToList();
            var availability = _repo.Filter<Availability>(e => e.userId == user!.userId).FirstOrDefault();
            var categories = _repo.GetAll<Category>().ToList(); // Load from database
            var cities = _repo.GetAll<City>().ToList(); // Load from database
            var subscriberCategories = _repo.Filter<UserCategory>(e => e.user_id == user!.userId).ToList();
            List<string> categoriesList = new List<string>();
            foreach (var subscriberCategory in subscriberCategories)
            {
                var category = categories.Where(e => e.id == subscriberCategory.category_id).FirstOrDefault();
                string categoryName = category.id.ToString();
                categoriesList.Add(categoryName);
            }
            var model = new ProfileModel
            {
                userId = currentUserModel?.userId,
                basicInfo = new BasicInfoModel
                {
                    FullName = user!.fullName,
                    Email = user.email,
                    Phone = user.mobile,
                    City = subscriber.city,
                    bio = subscriber.bio,
                    experience_years = subscriber.experience_years,
                    SelectedCategories = categoriesList,
                    AvailableCategories = categories.Select(c => new SelectListItem
                    {
                        Value = c.id.ToString(),
                        Text = c.name
                    }).ToList(),
                    Cities = cities
                },
                availability = new AvailabilityModel
                {
                    fromDay = availability?.fromDay,
                    toDay = availability?.toDay,
                    fromHour = availability?.fromHour,
                    toHour = availability?.toHour,
                },
                packageInfo = new PackageModel
                {
                    userPackages = userPacakges,
                }
            };
            return View(model);
        }
        [HttpPost]
        public async Task<Response> UpdateBasicInfo([FromForm] ProfileModel profileModel)
        {

            BasicInfoModel basicInfo = profileModel.basicInfo;
            Response response = new Response();
            response.Status = false;
            try
            {
                User user = _repo.Filter<User>(e => e.userId == decimal.Parse(profileModel.userId)).FirstOrDefault();
                user.email = basicInfo.Email;
                user.fullName = basicInfo.FullName;
                user.mobile = basicInfo.Phone;
                _repo.Update<User>(user);
                _repo.SaveChanges();
                Subscriber subscriber = _repo.Filter<Subscriber>(e => e.userId == decimal.Parse(profileModel.userId)).FirstOrDefault();
                subscriber.city = basicInfo.City;
                subscriber.experience_years = basicInfo.experience_years;
                subscriber.bio = basicInfo.bio;
                _repo.Update<Subscriber>(subscriber);
                _repo.SaveChanges();
                List<UserCategory> oldUserCategory = _repo.Filter<UserCategory>(e => e.user_id == user.userId).ToList();
                foreach (UserCategory category in oldUserCategory)
                {
                    _repo.Delete<UserCategory>(category);
                }
                _repo.SaveChanges();
                foreach (var category in basicInfo.SelectedCategories)
                {
                    UserCategory userCategory = new UserCategory();
                    userCategory.user_id = int.Parse(profileModel.userId);
                    userCategory.category_id = int.Parse(category);
                    _repo.Create<UserCategory>(userCategory);
                    _repo.SaveChanges();
                }
                response.Message = "Basic information updated";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "an error occurred";
            }
            return response;
        }

        [HttpPost]
        public async Task<Response> UpdatePackageInfo([FromForm] ProfileModel profileModel)
        {
            PackageModel packageInfo = profileModel.packageInfo;
            Response response = new Response();
            response.Status = false;
            try
            {
                List<Package> packages = _repo.Filter<Package>(e => e.user_id == int.Parse(profileModel.userId)).ToList();
                if (packages.Count <= 3)
                {
                    Package package = new Package();
                    package.user_id = int.Parse(profileModel.userId);
                    package.title = packageInfo.title;
                    package.price = packageInfo.price;
                    package.duration = packageInfo.duration;
                    package.description = packageInfo.description;
                    package.deliverables = packageInfo.deliverables;
                    _repo.Update<Package>(package);
                    _repo.SaveChanges();
                    response.Message = "package information updated";
                    response.Status = true;
                }
                else
                {
                    response.Message = "You already have 3 package";
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
