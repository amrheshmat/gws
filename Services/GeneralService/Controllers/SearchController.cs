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
        private IConfiguration _config;
        public SearchController(IConfiguration config, ILogger<ProfileController> logger, IRepositoryFactory repo, ISecurity security, ILanguageService languageService, ILocalizationService localizationService) : base(languageService, localizationService)
        {
            _logger = logger;
            _repo = repo.Create("AGGRDB");
            _security = security;
            _config = config;
            _localizationService = localizationService;
        }
        public IActionResult Index(int? page, string? category, string? city, string? name, decimal? price, string? sort)
        {
            var providersPaginationCount = int.Parse(_config.GetSection("ProvidersPaginationCount").Value!);
            // Prepare queryable data source (e.g., from EF Core)
            //var subscribers = _repo.Filter<Subscriber>(e=>e.status == UserStatus.Active).Skip(int.Parse(pageId) * 2).ToList();
            var query = new List<Subscriber>();
            var userCategory = _repo.GetAll<UserCategory>().ToList();
            var packagesUsers = _repo.GetAll<Package>().Select(e => e.user_id).ToList();
            query = _repo.GetAll<Subscriber>().Where(e => packagesUsers.Contains(e.userId)).ToList();
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
            var subscribers = query.ToList();
            var totalCount = subscribers.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / providersPaginationCount);
            if (page != null)
            {
                page = page - 1;
                query = _repo.GetAll<Subscriber>().Where(e => packagesUsers.Contains(e.userId)).Skip(page.Value * providersPaginationCount).Take(providersPaginationCount).ToList();
            }
            else
            {
                query = _repo.GetAll<Subscriber>().Where(e => packagesUsers.Contains(e.userId)).Skip(0).Take(providersPaginationCount).ToList();
            }
            List<subscriberModel> subscriberModelList = new List<subscriberModel>();
            foreach (var subscriber in query)
            {
                subscriberModel subscriberModel = new subscriberModel();
                var packages = _repo.Filter<Package>(e => e.user_id == subscriber.userId).ToList();
                subscriberModel.Packages = packages;
                subscriberModel.Name = subscriber.fullName;
                subscriberModel.Phone = subscriber.mobile;
                subscriberModel.City = subscriber.city;
                subscriberModel.ProfileImage = _repo.Filter<Attachment>(e => e.type == "Profile" && e.elementId == subscriber.userId).FirstOrDefault()?.attachmentPath;
                subscriberModelList.Add(subscriberModel);
            }
            var model = new ServiceProvidersModel
            {
                subscribers = subscriberModelList,
                totalCount = totalCount,
                totalPages = totalPages
            };
            List<City> cities = _repo.GetAll<City>().ToList();
            List<Category> categoriesList = _repo.GetAll<Category>().ToList();
            ViewBag.cities = cities;
            ViewBag.categories = categoriesList;

            return View(model);
        }

    }
}
