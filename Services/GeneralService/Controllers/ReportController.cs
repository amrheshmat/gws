using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        //[HttpGet]
        //[Route("Report/RequestReport/{startDate}/{endDate}")]
        //public async Task<IActionResult> RequestReport(DateTime startDate, DateTime endDate)
        //{
        //    var model = await _repo.Filter<User>(e => e.tourDate >= startDate && e.tourDate <= endDate).ToListAsync();
        //    List<RequestReportModel> requestReportModelList = new List<RequestReportModel>();
        //    if (model != null && model.Count > 0)
        //    {
        //        foreach (var booking in model)
        //        {
        //            RequestReportModel requestReportModel = new RequestReportModel();
        //            requestReportModel.id = booking.requestId;
        //            requestReportModel.tourDate = booking.tourDate.Value.ToString("dd/MM/yyyy");
        //            requestReportModel.countryName = booking.countryName;
        //            requestReportModel.tourName = _repo.Filter<Tour>(e => e.tourId == booking.tourId).FirstOrDefault()?.title;
        //            requestReportModel.name = booking.name;
        //            requestReportModel.email = booking.email;
        //            requestReportModel.phone = booking.phone;
        //            requestReportModel.numberOfAdult = booking.numberOfAdult;
        //            requestReportModel.numberOfChild = booking.numberOfChild;
        //            requestReportModel.numberOfInfant = booking.numberOfInfant;
        //            requestReportModel.status = booking.status;
        //            requestReportModelList.Add(requestReportModel);
        //        }
        //    }
        //    var peopleArray = requestReportModelList.ToArray();
        //    return Ok(peopleArray);
        //}

        [HttpGet]
        [Route("Report/UserReportData")]
        public async Task<IActionResult> UserReportData()
        {

            var model = await _repo.GetAll<User>().ToListAsync();
            var peopleArray = model.ToArray();
            return Ok(peopleArray);
        }
        [Route("Report/UserReport")]
        public async Task<IActionResult> UserReport()
        {
            return View();
        }
    }
}
