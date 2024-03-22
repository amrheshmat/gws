using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MWS.Business.Shared;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;

namespace SampleMVC.Controllers
{
    public class UserController : Controller
    {
        private IRepository _repo;
        public UserController(IRepositoryFactory repo)
        {
            _repo = repo.Create("AGGRDB");
        }
        [AuthAttribute("user", "user")]
        public async Task<IActionResult> User()//index page
        {
            List<User> users = await _repo.GetAll<User>().ToListAsync();
            List<Role> roles = await _repo.GetAll<Role>().ToListAsync();
            ViewBag.roles = roles;
            ViewBag.users = users;
            return View();

        }
        [AuthAttribute("edit", "user")]
        [HttpPost]
        [Route("User/Edit")]
        public async Task<IActionResult> Edit([FromBody] User userModel)
        {
            var oldUSer = _repo.Filter<User>(e => e.userId == userModel.userId).FirstOrDefault();
            userModel.password = oldUSer != null ? oldUSer.password : null;
            if (userModel.roleId == null)
                userModel.roleId = oldUSer != null ? oldUSer.roleId : null;
            if (oldUSer != null)
            {
                var user = _repo.context.Update(userModel);
                await _repo.context.SaveChangesAsync();
                return Ok("Updated");
            }
            return NotFound("notFound");
        }
        [AuthAttribute("add", "user")]
        [HttpPost]
        [Route("User/Add")]
        public async Task<IActionResult> Add([FromBody] User userModel)
        {
            userModel.creationDate = DateTime.Now;
            var user = await _repo.CreateAsync(userModel);
            await _repo.context.SaveChangesAsync();
            if (user?.userId != null)
            {
                return Ok("Added");
            }
            return NotFound("NotFound");

        }
        [AuthAttribute("delete", "user")]
        [HttpGet]
        [Route("User/Delete/{userId}")]
        public async Task<string> Delete(int userId)
        {
            var user = _repo.Filter<User>(e => e.userId == userId).FirstOrDefault();
            if (user != null)
            {
                _repo.Delete<User>(user);
                await _repo.context.SaveChangesAsync();
                return "Deleted";
            }
            return "NotFond";
        }
    }
}
