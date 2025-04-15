using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MWS.Business.Shared;
using MWS.Business.Shared.Data.Models;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;
using TripBusiness.Ibusiness;

namespace SampleMVC.Controllers
{
    public class UserController : Controller
    {
        private ILocalizationService _localizationService;
        private IRepository _repo;
        public UserController(ILocalizationService localizationService, IRepositoryFactory repo)
        {
            _repo = repo.Create("AGGRDB");
            _localizationService = localizationService;
        }
        [AuthAttribute("user", "user")]
        public async Task<IActionResult> User()//index page
        {
            List<User> users = await _repo.GetAll<User>().ToListAsync();
            List<Role> roles = await _repo.GetAll<Role>().ToListAsync();
            ViewBag.roles = roles;
            ViewBag.users = users;
            ViewBag.languages = _repo.GetAll<Language>().ToList();
            return View();

        }
        [AuthAttribute("edit", "user")]
        [HttpPost]
        [Route("User/Edit")]
        public async Task<Response> Edit([FromBody] User userModel)
        {
            Response response = new Response();
            response.Title = _localizationService.Localize("Update");
            var oldUSer = _repo.Filter<User>(e => e.userId == userModel.userId).FirstOrDefault();
            if (oldUSer != null)
            {
                userModel.password = oldUSer != null ? oldUSer.password : null;
                if (userModel.roleId == null)
                    userModel.roleId = oldUSer != null ? oldUSer.roleId : null;
                if (oldUSer != null)
                {
                    var user = _repo.context.Update(userModel);
                    await _repo.context.SaveChangesAsync();
                    response.Message = _localizationService.Localize("Updated");
                    response.Status = true;
                    return response;
                }
                response.Message = _localizationService.Localize("UpdatedError");
                response.Status = false;
                return response;
            }
            else
            {
                response.Message = _localizationService.Localize("UserNameExsits");
                response.Status = false;
                return response;
            }

        }
        [AuthAttribute("add", "user")]
        [HttpPost]
        [Route("User/Add")]
        public async Task<Response> Add([FromBody] User userModel)
        {
            Response response = new Response();
            response.Title = _localizationService.Localize("Add");
            var oldUser = _repo.Filter<User>(e => e.userName == userModel.userName).FirstOrDefault();
            if (oldUser == null)
            {
                userModel.creationDate = DateTime.Now;
                userModel.password = MPSSecurity.Hash(userModel.password);
                var user = await _repo.CreateAsync(userModel);
                await _repo.context.SaveChangesAsync();
                if (user?.userId != null)
                {
                    response.Message = _localizationService.Localize("Added");
                    response.Status = true;
                    return response;
                }
                response.Message = _localizationService.Localize("AddedError");
                response.Status = false;
                return response;
            }
            else
            {
                response.Message = _localizationService.Localize("UserNameExsits");
                response.Status = false;
                return response;
            }


        }
        [AuthAttribute("delete", "user")]
        [HttpGet]
        [Route("User/Delete/{userId}")]
        public async Task<Response> Delete(int userId)
        {
            Response response = new Response();
            response.Title = _localizationService.Localize("Delete");
            var user = _repo.Filter<User>(e => e.userId == userId).FirstOrDefault();
            if (user != null)
            {
                _repo.Delete<User>(user);
                await _repo.context.SaveChangesAsync();
                response.Message = _localizationService.Localize("Deleted");
                response.Status = true;
                return response;
            }
            response.Message = _localizationService.Localize("DeletedError");
            response.Status = false;
            return response;
        }
    }
}
