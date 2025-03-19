using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MWS.Business.Shared;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;

namespace SampleMVC.Controllers
{
    public class CountryController : Controller
    {
        private IRepository _repo;
        public CountryController(IRepositoryFactory repo)
        {
            _repo = repo.Create("AGGRDB");
        }
        [AuthAttribute("country", "country")]
        public async Task<IActionResult> Country()//index page
        {
            List<Country> countries = await _repo.GetAll<Country>().ToListAsync();
            ViewBag.countries = countries;
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Edit(Country countryModel)
        {
            var rolePermissions = _repo.Filter<Country>(e => e.countryId == countryModel.countryId).ToList();
            var Country = _repo.Update<Country>(countryModel);
            _repo.SaveChanges();
            if (Country != null)
            {
                return RedirectToAction("Country");
            }
            return RedirectToAction("Country");
        }
    }
}
