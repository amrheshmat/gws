using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Data.Entities
{
    public partial class Subscriber
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? id { get; set; }
        public decimal? userId { get; set; }

        public string? bio { get; set; }
        public string? isVerified { get; set; }

        public int? experience_years { get; set; }

        public string? location { get; set; }
        public string? city { get; set; }
        public string? planName { get; set; }
        public decimal? price { get; set; }
        public string? status { get; set; }
        public DateOnly? start_date { get; set; }
        public DateOnly? end_date { get; set; }
        public string? paymentMethod { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
