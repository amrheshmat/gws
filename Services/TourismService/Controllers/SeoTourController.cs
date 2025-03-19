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
    public class SeoController : Controller
    {
        private IRepository _repo;
        private ILocalizationService _localizationService;
        IWebHostEnvironment _appEnvironment;
        public SeoController(IRepositoryFactory repo, IWebHostEnvironment appEnvironment, ILocalizationService localizationService)
        {
            _repo = repo.Create("AGGRDB");
            _appEnvironment = appEnvironment;
            _localizationService = localizationService;
        }
        [Route("admin/seo")]
        public async Task<IActionResult> Edit()//index page
        {
            Seo seoModel = new Seo();
            seoModel = await _repo.GetAll<Seo>().FirstOrDefaultAsync();
            ViewBag.seo = seoModel;
            return View(seoModel);

        }
        //[AuthAttribute("Edit", "seo")]
        [HttpPost]
        public async Task<Response> Edit([FromBody] Seo seoModel)
        {
            Response response = new Response();
            response.Title = _localizationService.Localize("Update");
            var rolePermissions = _repo.Filter<Seo>(e => e.seoId == seoModel.seoId).ToList();
            var Seo = _repo.Update<Seo>(seoModel);
            _repo.SaveChanges();
            if (Seo != null)
            {
                response.Status = true;
                response.Message = _localizationService.Localize("Updated");
                return response;
            }
            response.Status = false;
            response.Message = _localizationService.Localize("UpdatedError");
            return response;
        }

    }
}
