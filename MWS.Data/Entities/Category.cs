using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Data.Entities
{
    public partial class Category
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? id { get; set; }
        public string? name { get; set; }
        public int? parent_id { get; set; }
        public string? slug { get; set; }
        public DateTime? created_at { get; set; }
    }
}
