using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MWS.Business.Shared;
using MWS.Business.Shared.Data.Models;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;
using SampleMVC.Models;
using TripBusiness.Ibusiness;

namespace SampleMVC.Controllers
{
    public class FQAController : Controller
    {
        private IRepository _repo;
        private readonly ILanguageService _languageService;
        private ILocalizationService _localizationService;

        public FQAController(ILanguageService languageService, IRepositoryFactory repo, ILocalizationService localizationService)
        {
            _repo = repo.Create("AGGRDB");
            _localizationService = localizationService;
            _languageService = languageService;
        }
        public async Task<IActionResult> index()//index page
        {
            var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;
            var language = _languageService.GetLanguageByCulture(currentCulture);
            List<Faq> faqs = await _repo.Filter<Faq>(e => e.languageId == language.languageId).OrderBy(e => e.orderId).ToListAsync();
            Seo homeSeo = await _repo.GetAll<Seo>().FirstOrDefaultAsync();
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
            ViewBag.languages = languages;
            homeSeo.title = homeSeo.title + " - faq";
            ViewBag.homeSeo = homeSeo;
            ViewBag.faqs = faqs;
            return View();

        }
        [AuthAttribute("faq", "admin")]
        [Route("admin/faq")]
        public async Task<IActionResult> AdminIndex()//index page
        {
            List<Faq> faqs = await _repo.GetAll<Faq>().ToListAsync();
            List<FaqModel> faqModels = new List<FaqModel>();
            foreach (Faq faq in faqs)
            {
                FaqModel faqModel = new FaqModel();
                faqModel.languageId = faq.languageId;
                faqModel.orderId = faq.orderId;
                faqModel.faqId = faq.faqId;
                faqModel.question = faq.question;
                faqModel.answer = faq.answer;
                faqModel.languageName = _repo.Filter<Language>(e => e.languageId == faq.languageId).FirstOrDefault()?.languageName;
                faqModels.Add(faqModel);
            }
            ViewBag.faqs = faqModels;
            List<Language> languages = await _repo.GetAll<Language>().ToListAsync();
            ViewBag.languages = languages;
            return View();
        }
        [HttpPost]
        [Route("faq/add")]
        public async Task<Response> Add([FromBody] Faq faqModel)
        {
            Response response = new Response();
            response.Title = _localizationService.Localize("Add");
            var Contact = _repo.Create<Faq>(faqModel);
            _repo.SaveChanges();
            if (Contact != null)
            {
                response.Status = true;
                response.Message = _localizationService.Localize("Added");
                return response;
            }
            response.Message = _localizationService.Localize("AddedError");
            response.Status = false;
            return response;
        }
        [HttpPost]
        [Route("faq/edit")]
        public async Task<Response> Edit([FromBody] Faq faqModel)
        {
            Response response = new Response();
            response.Title = _localizationService.Localize("Update");
            var Contact = _repo.Update<Faq>(faqModel);
            _repo.SaveChanges();
            if (Contact != null)
            {
                response.Status = true;
                response.Message = _localizationService.Localize("Updated");
                return response;
            }
            response.Message = _localizationService.Localize("UpdatedError");
            response.Status = false;
            return response;
        }
        [HttpGet]
        [Route("faq/Delete/{faqId}")]
        public async Task<Response> Delete(int faqId)
        {
            Response response = new Response();
            response.Title = _localizationService.Localize("Delete");
            var faq = _repo.Filter<Faq>(e => e.faqId == faqId).FirstOrDefault();
            if (faq != null)
            {
                _repo.Delete<Faq>(faq);
                await _repo.context.SaveChangesAsync();
                response.Message = _localizationService.Localize("Deleted");
                response.Status = true;
                return response;
            }
            response.Message = _localizationService.Localize("DeletedError");
            response.Status = false;
            return response;
        }
        [HttpGet]
        [Route("faq/getFaqById/{faqId}")]
        public async Task<Faq> getFaqById(int faqId)
        {
            Faq faq = null;
            faq = _repo.Filter<Faq>(e => e.faqId == faqId).FirstOrDefault();
            if (faq != null)
            {
                return faq;
            }
            return faq;
        }
    }
}
