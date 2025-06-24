using Microsoft.AspNetCore.Mvc;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;
using SampleMVC.Controllers;
using SampleMVC.Models;
using TripBusiness.Ibusiness;

namespace GeneralService.Controllers
{
    public class ServiceProvidersController : BaseController
    {
        private readonly ILogger<ProfileController> _logger;
        private IRepository _repo;
        private ILocalizationService _localizationService;
        private readonly IConfiguration _config;
        private ISecurity _security;
        private IWebHostEnvironment _env;
        public ServiceProvidersController(IConfiguration config, IWebHostEnvironment env, ILogger<ProfileController> logger, IRepositoryFactory repo, ISecurity security, ILanguageService languageService, ILocalizationService localizationService) : base(languageService, localizationService)
        {
            _logger = logger;
            _repo = repo.Create("AGGRDB");
            _security = security;
            _env = env;
            _localizationService = localizationService;
            _config = config;
        }
        public async Task<IActionResult> Index(int? page)
        {

            var providersPaginationCount = int.Parse(_config.GetSection("ProvidersPaginationCount").Value!);
            //var subscribers = _repo.Filter<Subscriber>(e=>e.status == UserStatus.Active).Skip(int.Parse(pageId) * 2).ToList();
            List<Subscriber> subscribers = new List<Subscriber>();
            var packagesUsers = _repo.GetAll<Package>().Select(e => e.user_id).ToList();
            if (page != null)
            {
                page = page - 1;
                subscribers = _repo.GetAll<Subscriber>().Where(e => packagesUsers.Contains(e.userId)).Skip(page.Value * providersPaginationCount).Take(providersPaginationCount).ToList();
            }
            else
            {
                subscribers = _repo.GetAll<Subscriber>().Where(e => packagesUsers.Contains(e.userId)).Skip(0).Take(providersPaginationCount).ToList();
            }
            var totalCount = _repo.Filter<Subscriber>(e => packagesUsers.Contains(e.userId)).Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / providersPaginationCount);

            //var subscribers = _repo.Filter<Subscriber>(e=>e.status == "A").ToList();
            List<subscriberModel> subscriberModelList = new List<subscriberModel>();
            foreach (var subscriber in subscribers)
            {
                subscriberModel subscriberModel = new subscriberModel();
                var packages = _repo.Filter<Package>(e => e.user_id == subscriber.userId).ToList();
                subscriberModel.Packages = packages;
                subscriberModel.Name = subscriber.fullName;
                subscriberModel.Phone = subscriber.mobile;
                subscriberModel.City = _repo.Filter<City>(e => e.id == int.Parse(subscriber.city)).FirstOrDefault().name;
                subscriberModel.ProfileImage = _repo.Filter<Attachment>(e => e.type == "Profile" && e.elementId == subscriber.userId).FirstOrDefault()?.attachmentPath;
                var userCategory = _repo.Filter<UserCategory>(e => e.user_id == subscriber.userId).Select(e => e.category_id).ToList();
                //List<string> categories = new List<string>();
                //foreach (var category in userCategory)
                //{
                //    var cqtegoryName = _repo.Filter<Category>(e => e.id == category).FirstOrDefault().name;
                //    categories.Add(cqtegoryName);
                //}
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
