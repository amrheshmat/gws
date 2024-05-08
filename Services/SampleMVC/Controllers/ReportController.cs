using Microsoft.AspNetCore.Mvc;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;
using TripBusiness.Ibusiness;

namespace SampleMVC.Controllers
{
    public class ReportController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private IRepository _repo;
        private readonly ILanguageService _languageService;
        private readonly IMailService mailService;
        public ReportController(IMailService mailService, ILanguageService languageService, ILocalizationService localizationService, ILogger<HomeController> logger, IRepositoryFactory repo)
       : base(languageService, localizationService)
        {
            _logger = logger;
            _repo = repo.Create("AGGRDB");
            this.mailService = mailService;
            _languageService = languageService;
        }
        [Route("Report/{name}")]
        public async Task<IActionResult> index(string name)//index page
        {
            return RedirectToAction(name, "Report");
        }
        [Route("Report/RequestReport")]
        public async Task<IActionResult> RequestReport()
        {
            return View();
        }
        [HttpGet]
        [Route("Report/RequestReport/{startDate}/{endDate}")]
        public async Task<IActionResult> RequestReport(DateTime startDate, DateTime endDate)
        {
            var model = _repo.Filter<Booking>(e => e.tourDate >= startDate && e.tourDate <= endDate).ToList();
            return RedirectToAction("RequestResult", "Report", model);
        }

    }
}
