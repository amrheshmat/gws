using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Data.Entities
{
    public partial class Package
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? id { get; set; }
        public int? user_id { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public decimal? price { get; set; }
        public string? duration { get; set; }
        public string? deliverables { get; set; }
        public DateTime? created_at { get; set; }
    }
}
