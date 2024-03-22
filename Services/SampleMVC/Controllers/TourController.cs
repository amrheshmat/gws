using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MWS.Business.Shared;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;
using SampleMVC.Models;

namespace SampleMVC.Controllers
{
    public class TourController : Controller
    {
        private IRepository _repo;
        IWebHostEnvironment _appEnvironment;
        public TourController(IRepositoryFactory repo, IWebHostEnvironment appEnvironment)
        {
            _repo = repo.Create("AGGRDB");
            _appEnvironment = appEnvironment;
        }
        [AuthAttribute("tour", "tour")]
        public async Task<IActionResult> Tour()//index page
        {
            List<Tour> tours = await _repo.GetAll<Tour>().ToListAsync();
            ViewBag.tours = tours;
            return View();

        }
        [AuthAttribute("Add", "tour")]
        public async Task<IActionResult> Add()//index page
        {
            List<Day> days = await _repo.GetAll<Day>().ToListAsync();
            ViewBag.days = days;
            return View();

        }
        [AuthAttribute("Add", "tour")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TourModel tour)//index page
        {
            Tour? myTour = tour.Tour;

            var createdTour = _repo.Create(myTour);
            _repo.SaveChanges();

            var id = createdTour?.tourId;
            if (id != null)
            {
                tour.Tour.tourId = id;
                await CreateLists(tour);
                return Ok("Added");
            }
            return NotFound("NotFound");

        }
        [Route("Tour/Edit/{id}")]
        public async Task<IActionResult> Edit(int id)//index page
        {
            TourModel tourModel = new TourModel();
            tourModel.Tour = await _repo.Filter<Tour>(e => e.tourId == id).FirstOrDefaultAsync();
            tourModel.includes = await _repo.Filter<Include>(e => e.tourId == id).ToListAsync();
            tourModel.excludes = await _repo.Filter<Exclude>(e => e.tourId == id).ToListAsync();
            tourModel.expects = await _repo.Filter<Expect>(e => e.tourId == id).ToListAsync();
            tourModel.packs = await _repo.Filter<Pack>(e => e.tourId == id).ToListAsync();
            tourModel.tourDays = await _repo.Filter<TourDay>(e => e.tourId == id).ToListAsync();
            List<Day> days = await _repo.GetAll<Day>().ToListAsync();
            ViewBag.days = days;
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
        public async Task<IActionResult> Edit([FromBody] TourModel tourModel)
        {
            var rolePermissions = _repo.Filter<Tour>(e => e.tourId == tourModel.Tour.tourId).ToList();
            var Tour = _repo.Update<Tour>(tourModel.Tour);
            _repo.SaveChanges();
            if (Tour != null)
            {
                List<Include>? includes = await _repo.Filter<Include>(e => e.tourId == tourModel.Tour.tourId).ToListAsync();
                List<Exclude>? excludes = await _repo.Filter<Exclude>(e => e.tourId == tourModel.Tour.tourId).ToListAsync();
                List<Expect>? expects = await _repo.Filter<Expect>(e => e.tourId == tourModel.Tour.tourId).ToListAsync();
                List<Pack>? packs = await _repo.Filter<Pack>(e => e.tourId == tourModel.Tour.tourId).ToListAsync();
                List<TourDay>? days = await _repo.Filter<TourDay>(e => e.tourId == tourModel.Tour.tourId).ToListAsync();
                List<TourAttachment>? attchments = await _repo.Filter<TourAttachment>(e => e.tourId == tourModel.Tour.tourId).ToListAsync();
                _repo.context.RemoveRange(includes);
                _repo.context.RemoveRange(excludes);
                _repo.context.RemoveRange(expects);
                _repo.context.RemoveRange(packs);
                _repo.context.RemoveRange(days);
                await _repo.context.SaveChangesAsync();
                await CreateLists(tourModel);
                return Ok("Updated");
            }
            return NotFound("NotFound");
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
        public async Task<string> Delete(int tourId)
        {
            var tour = _repo.Filter<Tour>(e => e.tourId == tourId).FirstOrDefault();
            if (tour != null)
            {
                List<Include>? includes = await _repo.Filter<Include>(e => e.tourId == tourId).ToListAsync();
                List<Exclude>? excludes = await _repo.Filter<Exclude>(e => e.tourId == tourId).ToListAsync();
                List<Expect>? expects = await _repo.Filter<Expect>(e => e.tourId == tourId).ToListAsync();
                List<Pack>? packs = await _repo.Filter<Pack>(e => e.tourId == tourId).ToListAsync();
                List<TourDay>? days = await _repo.Filter<TourDay>(e => e.tourId == tourId).ToListAsync();
                List<TourAttachment>? attchments = await _repo.Filter<TourAttachment>(e => e.tourId == tourId).ToListAsync();
                _repo.Delete<Tour>(tour);
                _repo.context.RemoveRange(includes);
                _repo.context.RemoveRange(excludes);
                _repo.context.RemoveRange(expects);
                _repo.context.RemoveRange(packs);
                _repo.context.RemoveRange(days);
                _repo.context.RemoveRange(attchments);
                await _repo.context.SaveChangesAsync();
                return "Deleted";
            }
            return "NotFond";
        }
        public async Task CreateLists(TourModel tour)
        {
            List<Include>? includes = tour.includes;
            List<Exclude>? excludes = tour.excludes;
            List<Expect>? expects = tour.expects;
            List<Pack>? packs = tour.packs;
            List<Day>? days = tour.days;
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
            foreach (var pack in packs)
            {
                pack.tourId = tour.Tour.tourId;
            }
            _repo.context.AddRange(packs);
            List<TourDay> tourDays = new List<TourDay>();
            foreach (var day in days)
            {
                TourDay dayTour = new TourDay();
                dayTour.tourId = (int)tour.Tour.tourId.Value;
                dayTour.dayId = day.dayId;
                tourDays.Add(dayTour);
            }
            _repo.context.AddRange(tourDays);
            _repo.SaveChanges();
        }
    }
}
