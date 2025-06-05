using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Data.Entities
{
    public partial class Availability
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? id { get; set; }
        public int? userId { get; set; }
        public string? fromHour { get; set; }
        public string? toHour { get; set; }
        public string? fromDay { get; set; }
        public string? toDay { get; set; }
        public string? toPeriod { get; set; }
        public string? fromPeriod { get; set; }
    }
}
