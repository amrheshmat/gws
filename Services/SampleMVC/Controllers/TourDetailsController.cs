using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;
using SampleMVC.Models;

namespace SampleMVC.Controllers
{
    public class TourDetailsController : Controller
    {
        private IRepository _repo;
        public TourDetailsController(IRepositoryFactory repo)
        {
            _repo = repo.Create("AGGRDB");
        }
        [Route("TourDetails/{id}")]
        public async Task<IActionResult> index(int id)//index page
        {

            TourModel tourModel = new TourModel();
            tourModel.Tour = await _repo.Filter<Tour>(e => e.tourId == id).FirstOrDefaultAsync();
            tourModel.includes = await _repo.Filter<Include>(e => e.tourId == id).ToListAsync();
            tourModel.excludes = await _repo.Filter<Exclude>(e => e.tourId == id).ToListAsync();
            tourModel.expects = await _repo.Filter<Expect>(e => e.tourId == id).ToListAsync();
            tourModel.packs = await _repo.Filter<Pack>(e => e.tourId == id).ToListAsync();
            tourModel.tourDays = await _repo.Filter<TourDay>(e => e.tourId == id).ToListAsync();
            List<Day> days = await _repo.GetAll<Day>().ToListAsync();
            List<TourAttachment> attachments = await _repo.Filter<TourAttachment>(e => e.tourId == id).ToListAsync();
            ViewBag.days = days;
            ViewBag.attachments = attachments;
            return View(tourModel);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(Tour tourModel)
        {
            var rolePermissions = _repo.Filter<Tour>(e => e.tourId == tourModel.tourId).ToList();
            var Tour = _repo.Update<Tour>(tourModel);
            _repo.SaveChanges();
            if (Tour != null)
            {
                return RedirectToAction("Tour");
            }
            return RedirectToAction("Tour");
        }
    }
}
