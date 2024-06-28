using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MWS.Business.Shared;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;

namespace SampleMVC.Controllers
{
    public class ContactController : Controller
    {
        private IRepository _repo;
        public ContactController(IRepositoryFactory repo)
        {
            _repo = repo.Create("AGGRDB");
        }
        [AuthAttribute("contact", "contact")]
        public async Task<IActionResult> Contact()//index page
        {
            List<Contact> contacts = await _repo.GetAll<Contact>().ToListAsync();
            ViewBag.contacts = contacts;
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Edit(Contact contactModel)
        {
            var rolePermissions = _repo.Filter<Contact>(e => e.contactId == contactModel.contactId).ToList();
            var Contact = _repo.Update<Contact>(contactModel);
            _repo.SaveChanges();
            if (Contact != null)
            {
                return RedirectToAction("Contact");
            }
            return RedirectToAction("Contact");
        }
    }
}
