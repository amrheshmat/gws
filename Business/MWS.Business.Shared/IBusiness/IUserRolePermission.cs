using MWS.Data.Entities;

namespace MWS.Business.Shared.IBusiness
{
    public interface IUserRolePermission
    {
        public Task<List<Permission>> getCurrentUserMenuPermissions(decimal roleId);
        public Task<List<Permission>> getCurrentUserPermissions(decimal roleId);
    }
}
