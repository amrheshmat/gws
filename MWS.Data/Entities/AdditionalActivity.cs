using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Data.Entities
{
    public partial class AdditionalActivity
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? additionalActivityId { get; set; }

        public string? title { get; set; }
        public decimal? adultPrice { get; set; }
        public decimal? childPrice { get; set; }
        public decimal? infantPrice { get; set; }
        public int? languageId { get; set; }
    }
}
