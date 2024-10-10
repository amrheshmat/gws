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
    public class FacilitiesController : Controller
    {
        private IRepository _repo;
        private readonly ILanguageService _languageService;
        private ILocalizationService _localizationService;

        public FacilitiesController(ILanguageService languageService, IRepositoryFactory repo, ILocalizationService localizationService)
        {
            _repo = repo.Create("AGGRDB");
            _localizationService = localizationService;
            _languageService = languageService;
        }
        public async Task<IActionResult> index()//index page
        {
            var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;
            var language = _languageService.GetLanguageByCulture(currentCulture);
            List<Facilities> facilitiess = await _repo.Filter<Facilities>(e => e.languageId == language.languageId).OrderBy(e => e.orderId).ToListAsync();
            List<TourAttachment> tourAttachments = new List<TourAttachment>();
            foreach (var tour in facilitiess)
            {
                List<TourAttachment> tourAttachment = new List<TourAttachment>();
                tourAttachment = await _repo.Filter<TourAttachment>(e => e.tourId == tour.facilitiesId && e.type == "facilities").ToListAsync();
                foreach (var attachment in tourAttachment)
                {
                    tourAttachments.Add(attachment);
                }
            }
            ViewBag.facilitiess = facilitiess;
            return View(tourAttachments);
        }
        [AuthAttribute("facilities", "admin")]
        [Route("admin/facilities")]
        public async Task<IActionResult> AdminIndex()//index page
        {
            List<Facilities> facilitiess = await _repo.GetAll<Facilities>().ToListAsync();
            List<FacilitiesModel> facilitiesModels = new List<FacilitiesModel>();
            foreach (Facilities facilities in facilitiess)
            {
                FacilitiesModel facilitiesModel = new FacilitiesModel();
                facilitiesModel.languageId = facilities.languageId;
                facilitiesModel.orderId = facilities.orderId;
                facilitiesModel.facilitiesId = facilities.facilitiesId;
                facilitiesModel.title = facilities.title;
                facilitiesModel.description = facilities.description;
                facilitiesModel.languageName = _repo.Filter<Language>(e => e.languageId == facilities.languageId).FirstOrDefault()?.languageName;
                facilitiesModels.Add(facilitiesModel);
            }
            ViewBag.facilitiess = facilitiesModels;
            List<Language> languages = await _repo.GetAll<Language>().ToListAsync();
            ViewBag.languages = languages;
            return View();
        }
        [HttpPost]
        [Route("facilities/add")]
        public async Task<Response> Add([FromBody] Facilities facilitiesModel)
        {
            Response response = new Response();
            response.Title = _localizationService.Localize("Add");
            var Contact = _repo.Create<Facilities>(facilitiesModel);
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
        [Route("facilities/edit")]
        public async Task<Response> Edit([FromBody] Facilities facilitiesModel)
        {
            Response response = new Response();
            response.Title = _localizationService.Localize("Update");
            var Contact = _repo.Update<Facilities>(facilitiesModel);
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
        [HttpPost]
        [Route("facilities/Upload")]
        public async Task<IActionResult> Upload([FromQuery] int tourId)
        {
            if (ModelState.IsValid)
            {
                List<TourAttachment> attachments = _repo.Filter<TourAttachment>(e => e.tourId == tourId && e.type == "facilities").ToList();
                _repo.context.RemoveRange(attachments);
                _repo.SaveChanges();
                var files = Request.Form.Files;

                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");

                //create folder if not exist
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                //get file extension
                foreach (var file in files)
                {
                    FileInfo fileInfo = new FileInfo(file.FileName);
                    var myUniqueFileName = string.Format(@"{0}", Guid.NewGuid());
                    TourAttachment tourAttachment = new TourAttachment();
                    tourAttachment.type = "facilities";
                    tourAttachment.tourId = tourId;
                    tourAttachment.attachmentName = file.Name;
                    tourAttachment.attachmentPath = myUniqueFileName + fileInfo.Extension;
                    _repo.Create(tourAttachment);
                    _repo.SaveChanges();
                    string fileName = myUniqueFileName + fileInfo.Extension;

                    string fileNameWithPath = Path.Combine(path, fileName);

                    using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                return Ok("Uploaded");
            }
            List<Tour> tours = await _repo.GetAll<Tour>().ToListAsync();
            ViewBag.tours = tours;
            return NotFound("NotFound");
        }
        [Route("facilities/GetAttachmentById/{id}")]
        [HttpGet]
        public async Task<List<TourAttachment>> GetAttachmentById(int id)//index page
        {
            List<TourAttachment> tourAttachment = await _repo.Filter<TourAttachment>(e => e.tourId == id && e.type == "facilities").ToListAsync();
            List<Tour> tours = await _repo.GetAll<Tour>().ToListAsync();
            ViewBag.tours = tours;
            return tourAttachment;

        }
        [HttpGet]
        [Route("facilities/Delete/{facilitiesId}")]
        public async Task<Response> Delete(int facilitiesId)
        {
            Response response = new Response();
            response.Title = _localizationService.Localize("Delete");
            var facilities = _repo.Filter<Facilities>(e => e.facilitiesId == facilitiesId).FirstOrDefault();
            if (facilities != null)
            {
                List<TourAttachment>? attchments = await _repo.Filter<TourAttachment>(e => e.tourId == facilitiesId && e.type == "facilities").ToListAsync();
                _repo.context.RemoveRange(attchments);
                _repo.Delete<Facilities>(facilities);
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
        [Route("facilities/getFacilitiesById/{facilitiesId}")]
        public async Task<Facilities> getFacilitiesById(int facilitiesId)
        {
            Facilities facilities = null;
            facilities = _repo.Filter<Facilities>(e => e.facilitiesId == facilitiesId).FirstOrDefault();
            if (facilities != null)
            {
                return facilities;
            }
            return facilities;
        }
    }
}
