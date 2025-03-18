using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MWS.Business.Shared;
using MWS.Business.Shared.Data.Models;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;
using TripBusiness.Ibusiness;

namespace SampleMVC.Controllers
{
    public class SettingController : Controller
    {
        private IRepository _repo;
        private ILocalizationService _localizationService;
        public SettingController(ILocalizationService localizationService, IRepositoryFactory repo)
        {
            _repo = repo.Create("AGGRDB");
            _localizationService = localizationService;
        }
        [AuthAttribute("setting", "setting")]
        [Route("admin/setting")]
        public async Task<IActionResult> AdminIndex()//index page
        {
            List<Setting> settings = await _repo.GetAll<Setting>().ToListAsync();
            ViewBag.settings = settings;
            return View();

        }
        [AuthAttribute("edit", "setting")]
        [HttpPost]
        [Route("setting/Edit")]
        public async Task<Response> Edit([FromBody] Setting settingModel)
        {
            Response response = new Response();
            response.Title = _localizationService.Localize("Update");
            var oldLocalize = await _repo.Filter<Setting>(e => e.settingId == settingModel.settingId).FirstOrDefaultAsync();
            if (oldLocalize != null)
            {
                var localize = _repo.Update(settingModel);
                await _repo.SaveChangesAsync();
                if (localize?.settingId != null)
                {
                    response.Message = _localizationService.Localize("Updated");
                    response.Status = true;
                    return response;
                }
            }
            response.Message = _localizationService.Localize("UpdatedError");
            response.Status = false;
            return response;
        }
        [HttpGet]
        [Route("setting/getSettingById/{settingId}")]
        public async Task<Setting> getSettingById(int settingId)
        {
            Setting term = null;
            term = _repo.Filter<Setting>(e => e.settingId == settingId).FirstOrDefault();
            if (term != null)
            {
                return term;
            }
            return term;
        }
    }
}
