using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Data.Entities
{
    public partial class Permission
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal? permissionId { get; set; }

        public string? permissionArea { get; set; }
        public string? permissionAction { get; set; }
        public string? permissionName { get; set; }
        public string? isMenu { get; set; }
        public string? icon { get; set; }
        public List<Role> roles { get; } = [];

    }
}
