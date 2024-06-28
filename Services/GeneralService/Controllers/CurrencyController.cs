using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MWS.Business.Shared;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;

namespace SampleMVC.Controllers
{
    public class CurrencyController : Controller
    {
        private IRepository _repo;
        public CurrencyController(IRepositoryFactory repo)
        {
            _repo = repo.Create("AGGRDB");
        }
        [AuthAttribute("currency", "currency")]
        public async Task<IActionResult> Currency()//index page
        {
            List<Currency> currencys = await _repo.GetAll<Currency>().ToListAsync();
            ViewBag.currencys = currencys;
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Edit(Currency currencyModel)
        {
            var rolePermissions = _repo.Filter<Currency>(e => e.currencyId == currencyModel.currencyId).ToList();
            var Currency = _repo.Update<Currency>(currencyModel);
            _repo.SaveChanges();
            if (Currency != null)
            {
                return RedirectToAction("Currency");
            }
            return RedirectToAction("Currency");
        }
    }
}
