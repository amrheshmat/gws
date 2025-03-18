using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Data.Entities
{
    public partial class Role
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal? roleId { get; set; }

        public string? roleName { get; set; }
        public List<User> users { get; set; } = [];
        public List<Permission> permissions { get; set; } = [];

    }
}
