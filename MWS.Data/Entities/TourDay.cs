using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Data.Entities
{
    public partial class TourDay
    {

        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? tourDayId { get; set; }
        public int? dayId { get; set; }

        public int? tourId { get; set; }


    }
}
