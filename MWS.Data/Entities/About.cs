using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Data.Entities
{
    public partial class About
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? aboutId { get; set; }

        public string? title { get; set; }
        public string? subject { get; set; }
        public int? orderId { get; set; }
        public int? languageId { get; set; }
    }
}
