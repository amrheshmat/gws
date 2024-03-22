using Microsoft.EntityFrameworkCore;
using MWS.Business.Shared.IBusiness;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;

namespace MWS.Business.Shared.Business
{
    public class UserRolePermission : IUserRolePermission
    {
        private ICommon _comm;
        private IRepository _repo;
        public UserRolePermission(ICommon comm, IRepositoryFactory reop)
        {
            _comm = comm;
            _repo = reop.Create("AGGRDB");
        }
        public async Task<List<Permission>> getCurrentUserMenuPermissions(decimal roleId)
        {
            //get Role ID ...
            //var currentUser = _comm.Getuser();
            Role userRole = new Role();
            List<Permission> userPermissions = new List<Permission>();
            var rolePermission = await _repo.Filter<RolePermission>(e => e.roleId == roleId).ToListAsync();
            foreach (var permission in rolePermission)
            {
                var userPermission = await _repo.Filter<Permission>(e => e.permissionId == permission.permissionId && e.isMenu == "Y").FirstOrDefaultAsync();
                userPermissions.Add(userPermission);
            }
            return userPermissions;
        }
        public async Task<List<Permission>> getCurrentUserPermissions(decimal roleId)
        {
            //get Role ID ...
            //var currentUser = _comm.Getuser();
            Role userRole = new Role();
            List<Permission> userPermissions = new List<Permission>();
            var rolePermission = await _repo.Filter<RolePermission>(e => e.roleId == roleId).ToListAsync();
            foreach (var permission in rolePermission)
            {
                var userPermission = await _repo.Filter<Permission>(e => e.permissionId == permission.permissionId).FirstOrDefaultAsync();
                userPermissions.Add(userPermission);
            }
            return userPermissions;
        }
    }
}
