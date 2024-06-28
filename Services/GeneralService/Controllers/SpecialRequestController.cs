using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MWS.Business.Shared;
using MWS.Business.Shared.Data.Models;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;
using TripBusiness.Ibusiness;

namespace SampleMVC.Controllers
{
	public class SpecialRequestController : Controller
	{
		private ILocalizationService _localizationService;
		private IMailService _mailService;
		private IRepository _repo;
		public SpecialRequestController(ILocalizationService localizationService, IRepositoryFactory repo, IMailService mailService)
		{
			_repo = repo.Create("AGGRDB");
			_localizationService = localizationService;
			_mailService = mailService;
		}
		[AuthAttribute("SpecialRequest", "SpecialRequest")]
		public async Task<IActionResult> SpecialRequest()//admin ...
		{
			List<SpecialRequest> specialRequests = await _repo.GetAll<SpecialRequest>().ToListAsync();
			ViewBag.specialRequests = specialRequests;
			return View();

		}
		public async Task<IActionResult> index()//client
		{
			return View();
		}
		[HttpPost]
		public async Task<Response> Add([FromBody] SpecialRequest specialRequestModel)
		{
			Response response = new Response();
			response.Title = _localizationService.Localize("SpecialRequest");
			response.Status = false;
			var SpecialRequest = _repo.Create<SpecialRequest>(specialRequestModel);
			_repo.SaveChanges();
			if (SpecialRequest != null)
			{
				MailRequest mailRequest = new MailRequest();
				mailRequest.spcialRequest = specialRequestModel;
				mailRequest.Subject = _localizationService.Localize("SpecialRequest");
				mailRequest.ToEmail = new List<string>();
				List<User> users = new List<User>();
				decimal? permissionId = _repo.Filter<Permission>(permission => permission.permissionArea.ToLower() == "SpecialRequest".ToLower()).FirstOrDefault().permissionId;
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
				if (users != null && users.Count > 0)
				{
					foreach (var user in users)
					{
						mailRequest.ToEmail?.Add(user.email);
					}
				}
				//send email to website users that have permission contacts ...
				await _mailService.SendSpecialEmailAsync(mailRequest);
				//send email to client ....
				mailRequest.ToEmail = new List<string>();
				mailRequest.ToEmail?.Add(specialRequestModel.email);
				mailRequest.Subject = _localizationService.Localize("ThankYou");
				mailRequest.spcialRequest.message = _localizationService.Localize("ThanksForContactWithUs") + ",<p>" + _localizationService.Localize("CheckSoon") + ".</p><p>" + _localizationService.Localize("Regards") + ",</p>";
				await _mailService.SendSpecialThankEmailAsync(mailRequest);
				response.Status = true;
				response.Message = _localizationService.Localize("SentMessage");
				return response;
			}
			response.Status = false;
			response.Message = _localizationService.Localize("SentMessageError");
			return response;
		}
	}
}
