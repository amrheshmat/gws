using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Data.Entities
{
    public partial class User
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal? userId { get; set; }

        public string? userName { get; set; }
        public string? fullName { get; set; }

        public string? gender { get; set; }

        public string? status { get; set; }

        public string? createdBy { get; set; }

        public DateTime? creationDate { get; set; }
        public string? lastUpdateBy { get; set; }
        public DateTime? lastUpdateDate { get; set; }
        public string? email { get; set; }
        public string? mobile { get; set; }
        public string? password { get; set; }
        public decimal? roleId { get; set; }
        public Role role { get; set; } = null!;

    }
}
