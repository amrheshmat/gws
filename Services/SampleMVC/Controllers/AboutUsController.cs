using Microsoft.AspNetCore.Mvc;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;

namespace SampleMVC.Controllers
{
    public class AboutUsController : Controller
    {
        private IRepository _repo;
        public AboutUsController(IRepositoryFactory repo)
        {
            _repo = repo.Create("AGGRDB");
        }
        public async Task<IActionResult> index()//index page
        {
            //List<Contact> contacts = await _repo.GetAll<Contact>().ToListAsync();
            //ViewBag.contacts = contacts;
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Contact contactModel)
        {
            var Contact = _repo.Create<Contact>(contactModel);
            _repo.SaveChanges();
            if (Contact != null)
            {
                return Ok("created");
            }
            return NotFound("notCreated");
        }
    }
}
