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
    public class AboutUsController : Controller
    {
        private ILocalizationService _localizationService;
        private readonly ILanguageService _languageService;
        private IRepository _repo;
        public AboutUsController(IRepositoryFactory repo, ILocalizationService localizationService, ILanguageService languageService)
        {
            _repo = repo.Create("AGGRDB");
            _localizationService = localizationService;
            _languageService = languageService;
        }
        public async Task<IActionResult> index()//index page
        {
            var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;
            var language = _languageService.GetLanguageByCulture(currentCulture);
            List<About> abouts = await _repo.Filter<About>(e => e.languageId == language.languageId).OrderBy(e => e.orderId).ToListAsync();
            Seo homeSeo = await _repo.GetAll<Seo>().FirstOrDefaultAsync();
            List<TourAttachment> tourAttachments = new List<TourAttachment>();
            foreach (var about in abouts)
            {
                List<TourAttachment> tourAttachment = new List<TourAttachment>();
                tourAttachment = await _repo.Filter<TourAttachment>(e => e.tourId == about.aboutId && e.type == "aboutus").ToListAsync();
                foreach (var attachment in tourAttachment)
                {
                    tourAttachments.Add(attachment);
                }
            }
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
            ViewBag.languages = languages;
            homeSeo.title = homeSeo.title + " - about us";
            ViewBag.homeSeo = homeSeo;
            ViewBag.toursAttachments = tourAttachments;
            ViewBag.abouts = abouts;
            return View(tourAttachments);

        }
        [AuthAttribute("about", "admin")]
        [Route("admin/about")]
        public async Task<IActionResult> AdminIndex()//index page
        {
            List<About> abouts = await _repo.GetAll<About>().ToListAsync();
            List<AboutModel> aboutModels = new List<AboutModel>();
            foreach (About about in abouts)
            {
                AboutModel aboutModel = new AboutModel();
                aboutModel.languageId = about.languageId;
                aboutModel.orderId = about.orderId;
                aboutModel.aboutId = about.aboutId;
                aboutModel.title = about.title;
                aboutModel.subject = about.subject;
                aboutModel.languageName = _repo.Filter<Language>(e => e.languageId == about.languageId).FirstOrDefault()?.languageName;
                aboutModels.Add(aboutModel);
            }
            ViewBag.abouts = aboutModels;
            List<Language> languages = await _repo.GetAll<Language>().ToListAsync();
            ViewBag.languages = languages;
            return View();
        }
        [HttpPost]
        [Route("about/add")]
        public async Task<Response> Add([FromBody] About aboutModel)
        {
            Response response = new Response();
            response.Title = _localizationService.Localize("Add");
            var Contact = _repo.Create<About>(aboutModel);
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
        [Route("about/edit")]
        public async Task<Response> Edit([FromBody] About aboutModel)
        {
            Response response = new Response();
            response.Title = _localizationService.Localize("Update");
            var Contact = _repo.Update<About>(aboutModel);
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
        [Route("about/Delete/{aboutId}")]
        public async Task<Response> Delete(int aboutId)
        {
            Response response = new Response();
            response.Title = _localizationService.Localize("Delete");
            var about = _repo.Filter<About>(e => e.aboutId == aboutId).FirstOrDefault();
            if (about != null)
            {
                _repo.Delete<About>(about);
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
        [Route("about/getAboutById/{aboutId}")]
        public async Task<About> getAboutById(int aboutId)
        {
            About about = null;
            about = _repo.Filter<About>(e => e.aboutId == aboutId).FirstOrDefault();
            if (about != null)
            {
                return about;
            }
            return about;
        }

        [HttpPost]
        [Route("aboutus/Upload")]
        public async Task<IActionResult> Upload([FromQuery] int tourId)
        {
            if (ModelState.IsValid)
            {
                List<TourAttachment> attachments = _repo.Filter<TourAttachment>(e => e.tourId == tourId && e.type == "aboutus").ToList();
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
                    tourAttachment.type = "aboutus";
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
        [Route("aboutus/GetAttachmentById/{id}")]
        [HttpGet]
        public async Task<List<TourAttachment>> GetAttachmentById(int id)
        {
            List<TourAttachment> tourAttachment = await _repo.Filter<TourAttachment>(e => e.tourId == id && e.type == "aboutus").ToListAsync();
            return tourAttachment;

        }
    }
}
