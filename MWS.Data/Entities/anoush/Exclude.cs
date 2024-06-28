using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Data.Entities.anoush
{
    public partial class Exclude
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal? excludeId { get; set; }

        public string? excludeText { get; set; }
        public decimal? tourId { get; set; }
    }
}
