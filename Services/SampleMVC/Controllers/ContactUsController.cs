using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MWS.Business.Shared.Data.Models;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;
using TripBusiness.Ibusiness;

namespace SampleMVC.Controllers
{
	public class ContactUsController : Controller
	{
		private IRepository _repo;
		private ILocalizationService _localizationService;
		private IMailService _mailService;
		public ContactUsController(IRepositoryFactory repo, IMailService mailService, ILocalizationService localizationService)
		{
			_repo = repo.Create("AGGRDB");
			_mailService = mailService;
			_localizationService = localizationService;
		}
		public async Task<IActionResult> ContactUs()//index page
		{
            //List<Contact> contacts = await _repo.GetAll<Contact>().ToListAsync();
            //ViewBag.contacts = contacts;
            Seo homeSeo = await _repo.GetAll<Seo>().FirstOrDefaultAsync();
            homeSeo.title = homeSeo.title + " - contact us";
            ViewBag.homeSeo = homeSeo;
            return View();

		}
		[HttpPost]
		public async Task<Response> Add([FromBody] Contact contactModel)
		{
			Response response = new Response();
			response.Title = _localizationService.Localize("Contact");
			response.Status = true;
			var Contact = _repo.Create<Contact>(contactModel);
			_repo.SaveChanges();
			if (Contact != null)
			{
				MailRequest mailRequest = new MailRequest();
				mailRequest.Contact = contactModel;
				mailRequest.Subject = _localizationService.Localize("Contact");
				mailRequest.ToEmail = new List<string>();
				List<User> users = new List<User>();
				decimal? permissionId = _repo.Filter<Permission>(permission => permission.permissionArea.ToLower() == "contact".ToLower()).FirstOrDefault().permissionId;
				if (permissionId != null)
				{
					List<RolePermission> role = _repo.Filter<RolePermission>(e => e.permissionId == permissionId).ToList();
					if (role != null)
					{
						foreach (RolePermission rolePermission in role)
						{
							List<User> usersForRole = new List<User>();
							usersForRole = _repo.Filter<User>(e => e.roleId == rolePermission.roleId).ToList();
							foreach (User user in usersForRole)
							{
								if (!users.Contains(user))
									users.Add(user);
							}
						}
					}
				}
				//get mails from user table base on permission ...
				if (users != null)
				{
					foreach (var user in users)
					{
						mailRequest.ToEmail?.Add(user.email);
					}
				}
				//send email to website users that have permission contacts ...
				await _mailService.SendContactEmailAsync(mailRequest);
				//send email to client ....
				mailRequest.ToEmail = new List<string>();
				mailRequest.ToEmail?.Add(contactModel.email);
				mailRequest.Subject = _localizationService.Localize("ThankYou");
				mailRequest.Contact.message = _localizationService.Localize("ThanksForContactWithUs") + ",<p>" + _localizationService.Localize("CheckSoon") + ".</p><p>" + _localizationService.Localize("Regards") + ",</p>";
				await _mailService.SendContactThankEmailAsync(mailRequest);
				response.Status = true;
				response.Message = _localizationService.Localize("ContactSent");
				return response;
			}
			response.Status = false;
			response.Message = _localizationService.Localize("ContactSent");
			return response;
		}
	}
}
