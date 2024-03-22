using Microsoft.AspNetCore.Mvc;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;
using TripBusiness.Ibusiness;

namespace SampleMVC.Controllers
{
    public class ContactUsController : Controller
    {
        private IRepository _repo;
        private IMailService _mailService;
        public ContactUsController(IRepositoryFactory repo, IMailService mailService)
        {
            _repo = repo.Create("AGGRDB");
            _mailService = mailService;
        }
        public async Task<IActionResult> ContactUs()//index page
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
                MailRequest mailRequest = new MailRequest();
                mailRequest.Contact = contactModel;
                mailRequest.Subject = "Contact";
                mailRequest.ToEmail = new List<string>();
                //TODO get mails from user table base on permission ...
                mailRequest.ToEmail?.Add("amrheshmat95@gmail.com");
                //send email to website users that have permission contacts ...
                await _mailService.SendContactEmailAsync(mailRequest);
                //send email to client ....
                mailRequest.ToEmail = new List<string>();
                mailRequest.ToEmail?.Add(contactModel.email);
                mailRequest.Subject = "Thank You!";
                mailRequest.Contact.message = "Thanks For Contact With Us,<p>We Will Check Your Message And Contact You as soon as Possible.</p><p>Regards,</p>";
                await _mailService.SendContactThankEmailAsync(mailRequest);
                return Ok("created");
            }
            return NotFound("notCreated");
        }
    }
}
