using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Data.Entities
{
    public partial class Facilities
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? facilitiesId { get; set; }

        public string? title { get; set; }
        public string? description { get; set; }
        public string? imagePath { get; set; }
        public int? orderId { get; set; }
        public int? languageId { get; set; }
    }
}
