using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Data.Entities
{
    public partial class BlockedDates
	{
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal? blockedDatesID { get; set; }

        public string? date { get; set; }
        public int? tourId { get; set; }
        public string? isPublic { get; set; }
    }
}
