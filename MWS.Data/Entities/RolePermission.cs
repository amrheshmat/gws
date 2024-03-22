using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Data.Entities
{
    public partial class RolePermission
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal? rolePermissionsId { get; set; }

        public decimal? roleId { get; set; }
        public decimal? permissionId { get; set; }
        public Permission permission { get; set; } = null!;
        public Role role { get; set; } = null!;
    }
}
