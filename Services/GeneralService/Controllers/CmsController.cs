using Microsoft.AspNetCore.Mvc;
using MWS.Business.Shared;
using MWS.Infrustructure.Repositories;
using TripBusiness.Ibusiness;

namespace SampleMVC.Controllers
{
    public class CmsController : Controller
    {
        private ILocalizationService _localizationService;
        private readonly ILanguageService _languageService;
        private IRepository _repo;
        public CmsController(IRepositoryFactory repo, ILocalizationService localizationService, ILanguageService languageService)
        {
            _repo = repo.Create("AGGRDB");
            _localizationService = localizationService;
            _languageService = languageService;
        }
        [AuthAttribute("cms", "admin")]
        [Route("admin/cms")]
        public async Task<IActionResult> index()//index page
        {
            return View();
        }
    }
}
