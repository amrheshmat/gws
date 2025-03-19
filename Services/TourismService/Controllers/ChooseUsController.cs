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
    public class ChooseUsController : Controller
    {
        private ILocalizationService _localizationService;
        private readonly ILanguageService _languageService;
        private IRepository _repo;
        public ChooseUsController(IRepositoryFactory repo, ILocalizationService localizationService, ILanguageService languageService)
        {
            _repo = repo.Create("AGGRDB");
            _localizationService = localizationService;
            _languageService = languageService;
        }

        [AuthAttribute("whyChooseUs", "admin")]
        [Route("admin/whyChooseUs")]
        public async Task<IActionResult> index()//index page
        {
            List<WhyChooseUs> whyChooseUs = await _repo.GetAll<WhyChooseUs>().ToListAsync();
            List<ChooseUsModel> aboutModels = new List<ChooseUsModel>();
            foreach (WhyChooseUs about in whyChooseUs)
            {
                ChooseUsModel aboutModel = new ChooseUsModel();
                aboutModel.languageId = about.languageId;
                aboutModel.title = about.title;
                aboutModel.id = about.id;
                aboutModel.languageName = _repo.Filter<Language>(e => e.languageId == about.languageId).FirstOrDefault()?.languageName;
                aboutModels.Add(aboutModel);
            }
            List<Language> languages = await _repo.GetAll<Language>().ToListAsync();
            ViewBag.languages = languages;
            ViewBag.whyChooseUs = aboutModels;
            return View();
        }
        [HttpPost]
        [Route("whyChooseUs/add")]
        public async Task<Response> Add([FromBody] WhyChooseUs whyChooseUsModel)
        {
            Response response = new Response();
            response.Title = _localizationService.Localize("Add");
            var Contact = _repo.Create<WhyChooseUs>(whyChooseUsModel);
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
        [Route("whyChooseUs/edit")]
        public async Task<Response> Edit([FromBody] WhyChooseUs whyChooseUsModel)
        {
            Response response = new Response();
            response.Title = _localizationService.Localize("Update");
            var Contact = _repo.Update<WhyChooseUs>(whyChooseUsModel);
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
        [Route("whyChooseUs/Delete/{whyChooseUsId}")]
        public async Task<Response> Delete(int whyChooseUsId)
        {
            Response response = new Response();
            response.Title = _localizationService.Localize("Delete");
            var whyChooseUs = _repo.Filter<WhyChooseUs>(e => e.id == whyChooseUsId).FirstOrDefault();
            if (whyChooseUs != null)
            {
                _repo.Delete<WhyChooseUs>(whyChooseUs);
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
        [Route("whyChooseUs/getWhyChooseUsById/{whyChooseUsId}")]
        public async Task<WhyChooseUs> getWhyChooseUsById(int whyChooseUsId)
        {
            WhyChooseUs whyChooseUs = null;
            whyChooseUs = _repo.Filter<WhyChooseUs>(e => e.id == whyChooseUsId).FirstOrDefault();
            if (whyChooseUs != null)
            {
                return whyChooseUs;
            }
            return whyChooseUs;
        }
    }
}
