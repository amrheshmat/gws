using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;
using SampleMVC.Controllers;
using SampleMVC.Models;
using TripBusiness.Ibusiness;

namespace GeneralService.Controllers
{
    public class SearchController : BaseController
    {
        private readonly ILogger<ProfileController> _logger;
        private IRepository _repo;
        private ILocalizationService _localizationService;
        private ISecurity _security;
        private IWebHostEnvironment _env;
        public SearchController(IWebHostEnvironment env, ILogger<ProfileController> logger, IRepositoryFactory repo, ISecurity security, ILanguageService languageService, ILocalizationService localizationService) : base(languageService, localizationService)
        {
            _logger = logger;
            _repo = repo.Create("AGGRDB");
            _security = security;
            _env = env;
            _localizationService = localizationService;
        }
        public async Task<IActionResult> Index()
        {
            var subscribers = _repo.GetAll<Subscriber>().ToList();
            //var subscribers = _repo.Filter<Subscriber>(e=>e.status == "A").ToList();
            List<subscriberModel> subscriberModelList = new List<subscriberModel>();
            foreach (var subscriber in subscribers)
            {
                subscriberModel subscriberModel = new subscriberModel();
                var packages = _repo.Filter<Package>(e => e.user_id == subscriber.userId).ToList();
                subscriberModel.Packages = packages;
                subscriberModel.Name = subscriber.fullName;
                subscriberModel.Phone = subscriber.mobile;
                subscriberModel.City = subscriber.city;
                subscriberModel.ProfileImage = _repo.Filter<Attachment>(e => e.type == "Profile" && e.elementId == subscriber.userId).FirstOrDefault()?.attachmentPath;
                var userCategory = _repo.Filter<UserCategory>(e => e.user_id == subscriber.userId).Select(e => e.category_id).ToList();
                List<string> categories = new List<string>();
                foreach (var category in userCategory)
                {
                    var cqtegoryName = _repo.Filter<Category>(e => e.id == category).FirstOrDefault().name;
                    categories.Add(cqtegoryName);
                }
                subscriberModelList.Add(subscriberModel);
            }
            var model = new ServiceProvidersModel
            {
                subscribers = subscriberModelList
            };

            List<City> cities = _repo.GetAll<City>().ToList();
            List<Category> categoriesList = _repo.GetAll<Category>().ToList();
            ViewBag.cities = cities;
            ViewBag.categories = categoriesList;
            return View(model);
        }
        public IActionResult Index(string? category, string? city, string? name, decimal? price, string? sort)
        {
            // Prepare queryable data source (e.g., from EF Core)
            var query = _repo.GetAll<Subscriber>().ToList();
            var userCategory = _repo.GetAll<UserCategory>().ToList();

            if (!string.IsNullOrWhiteSpace(category))
            {
                var users = _repo.Filter<UserCategory>(e => e.category_id == int.Parse(category)).ToList().Select(e => e.user_id);
                query = query.Where(i => users.Contains(i.userId)).ToList();
            }

            if (!string.IsNullOrWhiteSpace(city))
                query = query.Where(i => i.city == city).ToList();

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(i => i.fullName.Contains(name)).ToList();

            if (price.HasValue)
            {
                var users = _repo.Filter<Package>(e => e.price == price).ToList().Select(e => e.user_id);
                query = query.Where(i => users.Contains(i.userId)).ToList();
            }

            // Optional sort parameter
            switch (sort)
            {
                case "city":
                    query = query.OrderBy(i => i.city).ToList();
                    break;
                case "name":
                    query = query.OrderBy(i => i.fullName).ToList();
                    break;
                default:
                    // Optional default sorting
                    query = query.OrderBy(i => i.userId).ToList();
                    break;
            }

            var results = query.ToList();

            return View(results);
        }

    }
}
