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
    public class TermsController : Controller
    {
        private IRepository _repo;
        private ILocalizationService _localizationService;
        private readonly ILanguageService _languageService;
        public TermsController(ILanguageService languageService, IRepositoryFactory repo, ILocalizationService localizationService)
        {
            _repo = repo.Create("AGGRDB");
            _localizationService = localizationService;
            _languageService = languageService;
        }
        public async Task<IActionResult> index()//index page
        {
            var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;
            var language = _languageService.GetLanguageByCulture(currentCulture);
            List<Term> terms = await _repo.Filter<Term>(e => e.languageId == language.languageId).OrderBy(e => e.orderId).ToListAsync();
            Seo homeSeo = await _repo.GetAll<Seo>().FirstOrDefaultAsync();
            homeSeo.title = homeSeo.title + " - terms";
            ViewBag.homeSeo = homeSeo;
            ViewBag.terms = terms;
            return View();

        }
        [AuthAttribute("term", "admin")]
        [Route("admin/term")]
        public async Task<IActionResult> AdminIndex()//index page
        {
            List<Term> terms = await _repo.GetAll<Term>().ToListAsync();
            List<TermModel> termModels = new List<TermModel>();
            foreach (Term term in terms)
            {
                TermModel termModel = new TermModel();
                termModel.languageId = term.languageId;
                termModel.orderId = term.orderId;
                termModel.termId = term.termId;
                termModel.title = term.title;
                termModel.subject = term.subject;
                termModel.languageName = _repo.Filter<Language>(e => e.languageId == term.languageId).FirstOrDefault()?.languageName;
                termModels.Add(termModel);
            }
            ViewBag.terms = termModels;
            List<Language> languages = await _repo.GetAll<Language>().ToListAsync();
            ViewBag.languages = languages;
            return View();

        }
        [HttpPost]
        [Route("term/add")]
        public async Task<Response> Add([FromBody] Term termModel)
        {
            Response response = new Response();
            response.Title = _localizationService.Localize("Add");
            var Contact = _repo.Create<Term>(termModel);
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
        [Route("term/edit")]
        public async Task<Response> Edit([FromBody] Term termModel)
        {
            Response response = new Response();
            response.Title = _localizationService.Localize("Update");
            var Contact = _repo.Update<Term>(termModel);
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
        [Route("term/Delete/{termId}")]
        public async Task<Response> Delete(int termId)
        {
            Response response = new Response();
            response.Title = _localizationService.Localize("Delete");
            var term = _repo.Filter<Term>(e => e.termId == termId).FirstOrDefault();
            if (term != null)
            {
                _repo.Delete<Term>(term);
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
        [Route("term/getTermById/{termId}")]
        public async Task<Term> getTermById(int termId)
        {
            Term term = null;
            term = _repo.Filter<Term>(e => e.termId == termId).FirstOrDefault();
            if (term != null)
            {
                return term;
            }
            return term;
        }
    }
}
