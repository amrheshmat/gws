using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MWS.Business.Shared;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;
using SampleMVC.Models;

namespace SampleMVC.Controllers
{
    public class RoleController : Controller
    {
        private IRepository _repo;
        public RoleController(IRepositoryFactory repo)
        {
            _repo = repo.Create("AGGRDB");
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
        public async Task<IActionResult> Add([FromBody] Role roleModel)
        {
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
                return Ok("Added");
            }
            return NotFound("NotFound");
        }
        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] Role roleModel)
        {
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
                return Ok("Updated");
            }
            return NotFound("NotFound");
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
        public async Task<string> Delete(int roleId)
        {
            var role = _repo.Filter<Role>(e => e.roleId == roleId).FirstOrDefault();
            if (role != null)
            {
                _repo.Delete<Role>(role);
                await _repo.context.SaveChangesAsync();
                return "Deleted";
            }
            return "NotFond";
        }
    }
}
