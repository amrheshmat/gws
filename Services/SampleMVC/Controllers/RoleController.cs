using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MWS.Business.Shared;
using MWS.Business.Shared.Data.Models;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;
using SampleMVC.Models;
using TripBusiness.Ibusiness;

namespace SampleMVC.Controllers
{
    public class RoleController : Controller
    {
        private ILocalizationService _localizationService;
        private IRepository _repo;
        public RoleController(ILocalizationService localizationService, IRepositoryFactory repo)
        {
            _repo = repo.Create("AGGRDB");
            _localizationService = localizationService;
        }
        [AuthAttribute("role", "role")]
        public async Task<IActionResult> Role()//index page
        {
            List<Role> roles = await _repo.GetAll<Role>().ToListAsync();
            RoleModel roleModel = new RoleModel();
            List<Permission> permissions = await _repo.GetAll<Permission>().ToListAsync();
            List<RolePermission> rolePermissions = null;
            foreach (var role in roles)
            {
                rolePermissions = await _repo.Filter<RolePermission>(e => e.roleId == role.roleId).ToListAsync();
                if (rolePermissions != null && rolePermissions.Count > 0)
                {
                    foreach (var permission in rolePermissions)
                    {
                        Permission per = new Permission();
                        per = await _repo.Filter<Permission>(e => e.permissionId == permission.permissionId).FirstOrDefaultAsync();
                        role.permissions.Add(per);
                    }
                }
            }
            ViewBag.roles = roles;
            //ViewBag.permissions = new SelectList(permissions, "permissionId", "permissionName");
            ViewBag.permissions = permissions;

            return View();

        }

        [HttpPost]
        public async Task<Response> Add([FromBody] Role roleModel)
        {
            Response response = new Response();
            response.Title = _localizationService.Localize("Add");
            Role role = new Role();
            role.roleName = roleModel.roleName;
            var createdRole = _repo.Create(role);
            _repo.SaveChanges();
            if (createdRole != null)
            {
                List<RolePermission> rolePermissions = new List<RolePermission>();
                foreach (var permission in roleModel.permissions)
                {
                    RolePermission rolePermission = new RolePermission();
                    rolePermission.permissionId = permission.permissionId;
                    rolePermission.roleId = createdRole.roleId;
                    rolePermissions.Add(rolePermission);
                }
                await _repo.context.AddRangeAsync(rolePermissions);
                await _repo.SaveChangesAsync();
                response.Message = _localizationService.Localize("Added");
                response.Status = true;
                return response;
            }
            response.Message = _localizationService.Localize("AddedError");
            response.Status = false;
            return response;
        }
        [HttpPost]
        public async Task<Response> Edit([FromBody] Role roleModel)
        {
            Response response = new Response();
            response.Title = _localizationService.Localize("Update");
            var rolePermissions = _repo.Filter<RolePermission>(e => e.roleId == roleModel.roleId).ToList();
            foreach (var rolePermission in rolePermissions)
            {
                _repo.Delete(rolePermission);
            }
            foreach (var selectedPermssion in roleModel.permissions)
            {
                RolePermission selectedRolePermission = new RolePermission();
                selectedRolePermission.roleId = roleModel.roleId;
                selectedRolePermission.permissionId = selectedPermssion.permissionId;
                _repo.Create(selectedRolePermission);
            }
            roleModel.permissions = new List<Permission>();
            var Role = _repo.Update<Role>(roleModel);
            _repo.SaveChanges();
            if (Role != null)
            {
                response.Message = _localizationService.Localize("Updated");
                response.Status = true;
                return response;
            }
            response.Message = _localizationService.Localize("UpdatedError");
            response.Status = false;
            return response;
        }

        [Route("Role/Edit/{id}")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Role role = await _repo.Filter<Role>(e => e.roleId == id).FirstOrDefaultAsync();
            List<RolePermission> rolePermissions = await _repo.Filter<RolePermission>(e => e.roleId == id).ToListAsync();
            List<Permission> permissions = new List<Permission>();
            List<Permission> allPermissions = _repo.GetAll<Permission>().ToList();
            foreach (var rolePermission in rolePermissions)
            {
                Permission permission = _repo.Filter<Permission>(e => e.permissionId == rolePermission.permissionId).FirstOrDefault();
                permissions.Add(permission);
            }
            role.permissions = permissions;
            ViewBag.permissions = allPermissions;
            return View(role);
        }

        [HttpGet]
        [Route("Role/Delete/{roleId}")]
        public async Task<Response> Delete(int roleId)
        {
            Response response = new Response();
            response.Title = _localizationService.Localize("Delete");
            var role = _repo.Filter<Role>(e => e.roleId == roleId).FirstOrDefault();
            if (role != null)
            {
                _repo.Delete<Role>(role);
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
