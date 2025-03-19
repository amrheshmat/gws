using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;
using TripBusiness.Ibusiness;

namespace SampleMVC.Controllers
{
    public class PaymentController : Controller
    {
        private ILocalizationService _localizationService;
        private IMailService _mailService;
        private IRepository _repo;
        public PaymentController(ILocalizationService localizationService, IRepositoryFactory repo, IMailService mailService)
        {
            _repo = repo.Create("AGGRDB");
            _localizationService = localizationService;
            _mailService = mailService;
        }
        [Route("payment/result/status/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.paymentResult = id;
            List<TourAttachment> tourAttachments = new List<TourAttachment>();
            List<Language> languages = await _repo.GetAll<Language>().ToListAsync();
            foreach (var lan in languages)
            {
                List<TourAttachment> tourAttachment = new List<TourAttachment>();
                tourAttachment = await _repo.Filter<TourAttachment>(e => e.tourId == lan.languageId && e.type == "language").ToListAsync();
                foreach (var attachment in tourAttachment)
                {
                    tourAttachments.Add(attachment);
                }
            }
            ViewBag.toursAttachments = tourAttachments;
            return View();
        }
    }
}
