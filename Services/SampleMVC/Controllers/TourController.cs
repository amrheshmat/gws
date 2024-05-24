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
    public class TourController : Controller
    {
        private IRepository _repo;
        private ILocalizationService _localizationService;
        IWebHostEnvironment _appEnvironment;
        public TourController(IRepositoryFactory repo, IWebHostEnvironment appEnvironment, ILocalizationService localizationService)
        {
            _repo = repo.Create("AGGRDB");
            _appEnvironment = appEnvironment;
            _localizationService = localizationService;
        }
        [AuthAttribute("tour", "tour")]
        public async Task<IActionResult> Tour()//index page
        {
            List<Tour> tours = await _repo.GetAll<Tour>().ToListAsync();
            List<TourViewModel> list = new List<TourViewModel>();
            foreach (Tour tour in tours)
            {
                TourViewModel tourViewModel = new TourViewModel();
                var lang = _repo.Filter<Language>(e => e.languageId == tour.languageId).FirstOrDefault()?.languageName;
                tourViewModel.languageName = lang;
                tourViewModel.title = tour.title;
                tourViewModel.tourId = tour.tourId;
                list.Add(tourViewModel);
            }
            ViewBag.tours = list;
            return View();

        }
        [AuthAttribute("Add", "tour")]
        public async Task<IActionResult> Add()//index page
        {
            List<Day> days = await _repo.GetAll<Day>().ToListAsync();
            List<Language> languages = await _repo.GetAll<Language>().ToListAsync();
            List<AdditionalActivity> activities = await _repo.GetAll<AdditionalActivity>().ToListAsync();
            ViewBag.languages = languages;
            ViewBag.activities = activities;
            ViewBag.days = days;
            return View();

        }
        [AuthAttribute("add", "tour")]
        [HttpPost]
        public async Task<Response> Add([FromBody] TourModel tour)//index page
        {
            Response response = new Response();
            response.Title = _localizationService.Localize("Add");
            Tour? myTour = tour.Tour;
            var createdTour = _repo.Create(myTour);
            _repo.SaveChanges();

            var id = createdTour?.tourId;
            if (id != null)
            {
                tour.Tour.tourId = id;
                await CreateLists(tour);
                response.Status = true;
                response.Message = _localizationService.Localize("Added");
                return response;
            }
            response.Status = false;
            response.Message = _localizationService.Localize("AddedError");
            return response;

        }
        [AuthAttribute("Edit", "tour")]
        [Route("Tour/Edit/{id}")]
        public async Task<IActionResult> Edit(int id)//index page
        {
            TourModel tourModel = new TourModel();
            tourModel.Tour = await _repo.Filter<Tour>(e => e.tourId == id).FirstOrDefaultAsync();
            tourModel.includes = await _repo.Filter<Include>(e => e.tourId == id).ToListAsync();
            tourModel.excludes = await _repo.Filter<Exclude>(e => e.tourId == id).ToListAsync();
            tourModel.expects = await _repo.Filter<Expect>(e => e.tourId == id).ToListAsync();
            //tourModel.packs = await _repo.Filter<Pack>(e => e.tourId == id).ToListAsync();
            tourModel.additionalInformations = await _repo.Filter<AdditionalInformation>(e => e.tourId == id).ToListAsync();
            tourModel.tourDays = await _repo.Filter<TourDay>(e => e.tourId == id).ToListAsync();
            tourModel.tourLanguages = await _repo.Filter<TourLanguage>(e => e.tourId == id).ToListAsync();
            tourModel.tourAdditionalActivities = await _repo.Filter<TourAdditionalActivity>(e => e.tourId == id).ToListAsync();
            List<Day> days = await _repo.GetAll<Day>().ToListAsync();
            List<Language> languages = await _repo.GetAll<Language>().ToListAsync();
            List<AdditionalActivity> activities = await _repo.GetAll<AdditionalActivity>().ToListAsync();
            ViewBag.days = days;
            ViewBag.languages = languages;
            ViewBag.activities = activities;
            ViewBag.tour = tourModel.Tour;
            return View(tourModel);

        }
        [Route("Tour/GetAttachmentById/{id}")]
        [HttpGet]
        public async Task<List<TourAttachment>> GetAttachmentById(int id)//index page
        {
            List<TourAttachment> tourAttachment = await _repo.Filter<TourAttachment>(e => e.tourId == id).ToListAsync();
            List<Tour> tours = await _repo.GetAll<Tour>().ToListAsync();
            ViewBag.tours = tours;
            return tourAttachment;

        }
        [AuthAttribute("Edit", "tour")]
        [HttpPost]
        public async Task<Response> Edit([FromBody] TourModel tourModel)
        {
            Response response = new Response();
            response.Title = _localizationService.Localize("Update");
            var rolePermissions = _repo.Filter<Tour>(e => e.tourId == tourModel.Tour.tourId).ToList();
            var Tour = _repo.Update<Tour>(tourModel.Tour);
            _repo.SaveChanges();
            if (Tour != null)
            {
                List<Include>? includes = await _repo.Filter<Include>(e => e.tourId == tourModel.Tour.tourId).ToListAsync();
                List<Exclude>? excludes = await _repo.Filter<Exclude>(e => e.tourId == tourModel.Tour.tourId).ToListAsync();
                List<Expect>? expects = await _repo.Filter<Expect>(e => e.tourId == tourModel.Tour.tourId).ToListAsync();
                //List<Pack>? packs = await _repo.Filter<Pack>(e => e.tourId == tourModel.Tour.tourId).ToListAsync();
                List<AdditionalInformation>? additionalInformations = await _repo.Filter<AdditionalInformation>(e => e.tourId == tourModel.Tour.tourId).ToListAsync();
                List<TourDay>? days = await _repo.Filter<TourDay>(e => e.tourId == tourModel.Tour.tourId).ToListAsync();
                List<TourLanguage>? languages = await _repo.Filter<TourLanguage>(e => e.tourId == tourModel.Tour.tourId).ToListAsync();
                List<TourAdditionalActivity>? activities = await _repo.Filter<TourAdditionalActivity>(e => e.tourId == tourModel.Tour.tourId).ToListAsync();
                List<TourAttachment>? attchments = await _repo.Filter<TourAttachment>(e => e.tourId == tourModel.Tour.tourId).ToListAsync();
                _repo.context.RemoveRange(includes);
                _repo.context.RemoveRange(excludes);
                _repo.context.RemoveRange(expects);
                _repo.context.RemoveRange(additionalInformations);
                //_repo.context.RemoveRange(packs);
                _repo.context.RemoveRange(days);
                _repo.context.RemoveRange(languages);
                _repo.context.RemoveRange(activities);
                await _repo.context.SaveChangesAsync();
                await CreateLists(tourModel);
                response.Status = true;
                response.Message = _localizationService.Localize("Updated");
                return response;
            }
            response.Status = false;
            response.Message = _localizationService.Localize("UpdatedError");
            return response;
        }
        [HttpPost]
        [Route("Tour/Upload")]
        public async Task<IActionResult> Upload([FromQuery] int tourId)
        {
            if (ModelState.IsValid)
            {
                List<TourAttachment> attachments = _repo.Filter<TourAttachment>(e => e.tourId == tourId).ToList();
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
        [HttpGet]
        [Route("Tour/Delete/{tourId}")]
        public async Task<Response> Delete(int tourId)
        {
            Response response = new Response();
            response.Title = _localizationService.Localize("Delete");
            var tour = _repo.Filter<Tour>(e => e.tourId == tourId).FirstOrDefault();
            if (tour != null)
            {
                List<Include>? includes = await _repo.Filter<Include>(e => e.tourId == tourId).ToListAsync();
                List<Exclude>? excludes = await _repo.Filter<Exclude>(e => e.tourId == tourId).ToListAsync();
                List<Expect>? expects = await _repo.Filter<Expect>(e => e.tourId == tourId).ToListAsync();
                //List<Pack>? packs = await _repo.Filter<Pack>(e => e.tourId == tourId).ToListAsync();
                List<AdditionalInformation>? additionalInformations = await _repo.Filter<AdditionalInformation>(e => e.tourId == tourId).ToListAsync();
                List<TourDay>? days = await _repo.Filter<TourDay>(e => e.tourId == tourId).ToListAsync();
                List<TourLanguage>? languages = await _repo.Filter<TourLanguage>(e => e.tourId == tourId).ToListAsync();
                List<TourAdditionalActivity>? activities = await _repo.Filter<TourAdditionalActivity>(e => e.tourId == tourId).ToListAsync();
                List<TourAttachment>? attchments = await _repo.Filter<TourAttachment>(e => e.tourId == tourId).ToListAsync();
                _repo.Delete<Tour>(tour);
                _repo.context.RemoveRange(includes);
                _repo.context.RemoveRange(excludes);
                _repo.context.RemoveRange(expects);
                //_repo.context.RemoveRange(packs);
                _repo.context.RemoveRange(additionalInformations);
                _repo.context.RemoveRange(days);
                _repo.context.RemoveRange(languages);
                _repo.context.RemoveRange(activities);
                _repo.context.RemoveRange(attchments);
                await _repo.context.SaveChangesAsync();
                response.Status = true;
                response.Message = _localizationService.Localize("Deleted");
                return response;
            }
            response.Status = false;
            response.Message = _localizationService.Localize("DeletedError");
            return response;
        }
        public async Task CreateLists(TourModel tour)
        {
            List<Include>? includes = tour.includes;
            List<Exclude>? excludes = tour.excludes;
            List<Expect>? expects = tour.expects;
            //List<Pack>? packs = tour.packs;
            List<AdditionalInformation>? additionalInformations = tour.additionalInformations;
            List<Day>? days = tour.days;
            List<Language>? languages = tour.Languages;
            List<AdditionalActivity>? activities = tour.activities;
            foreach (var include in includes)
            {
                include.tourId = tour.Tour.tourId;
            }
            _repo.context.AddRange(includes);
            foreach (var exclude in excludes)
            {
                exclude.tourId = tour.Tour.tourId;
            }
            int r = excludes.RemoveAll(e => e.excludeText == "");
            _repo.context.AddRange(excludes);
            foreach (var expect in expects)
            {
                expect.tourId = tour.Tour.tourId;
            }
            _repo.context.AddRange(expects);
            //foreach (var pack in packs)
            //{
            //	pack.tourId = tour.Tour.tourId;
            //}
            //_repo.context.AddRange(packs);
            foreach (var additionalInformation in additionalInformations)
            {
                additionalInformation.tourId = tour.Tour.tourId;
            }
            _repo.context.AddRange(additionalInformations);
            List<TourDay> tourDays = new List<TourDay>();
            foreach (var day in days)
            {
                TourDay dayTour = new TourDay();
                dayTour.tourId = (int)tour.Tour.tourId.Value;
                dayTour.dayId = day.dayId;
                tourDays.Add(dayTour);
            }
            _repo.context.AddRange(tourDays);
            List<TourLanguage> tourLanguages = new List<TourLanguage>();
            foreach (var language in languages)
            {
                TourLanguage tourLanguage = new TourLanguage();
                tourLanguage.tourId = (int)tour.Tour.tourId.Value;
                tourLanguage.languageId = int.Parse(language.languageId.ToString());
                tourLanguage.languageName = _repo.Filter<Language>(e => e.languageId == language.languageId).FirstOrDefault().languageName;
                tourLanguages.Add(tourLanguage);
            }
            _repo.context.AddRange(tourLanguages);
            List<TourAdditionalActivity> tourActivities = new List<TourAdditionalActivity>();
            foreach (var activity in activities)
            {
                TourAdditionalActivity tourActivity = new TourAdditionalActivity();
                tourActivity.tourId = (int)tour.Tour.tourId.Value;
                tourActivity.activityId = int.Parse(activity.additionalActivityId.ToString());
                tourActivities.Add(tourActivity);
            }
            _repo.context.AddRange(tourActivities);
            _repo.SaveChanges();
        }
    }
}
