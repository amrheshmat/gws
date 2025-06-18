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
        private ISecurity _security;
        private IWebHostEnvironment _env;
        public ServiceProvidersController(IWebHostEnvironment env, ILogger<ProfileController> logger, IRepositoryFactory repo, ISecurity security, ILanguageService languageService, ILocalizationService localizationService) : base(languageService, localizationService)
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
            return View(model);
        }
    }
}
