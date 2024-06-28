using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Data.Entities.anoush
{
    public partial class Expect
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal? expectId { get; set; }

        public string? title { get; set; }
        public string? details { get; set; }
        public decimal? tourId { get; set; }
    }
}
