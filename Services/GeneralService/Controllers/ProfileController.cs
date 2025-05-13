using Microsoft.AspNetCore.Mvc;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;
using SampleMVC.Controllers;
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
            ViewData["users"] = await Localize("users");
            if (currentUser == null)
                return RedirectToAction("Index", "Login");
            ViewBag.NumberOfUsers = _repo.GetAll<User>().ToList().Count();
            ViewBag.NumberOfRoles = _repo.GetAll<Role>().ToList().Count();
            ViewBag.languages = _repo.GetAll<Language>().ToList();

            return View();
        }
    }
}
