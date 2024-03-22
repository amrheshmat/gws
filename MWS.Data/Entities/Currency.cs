using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Data.Entities
{
    public partial class Currency
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal? currencyId { get; set; }

        public string? currencyName { get; set; }
        public string? currencyCode { get; set; }

        //public string? createdBy { get; set; }

        //public DateTime? creationDate { get; set; }

        //public string? lastUpdateBy { get; set; }

        //public DateTime? lastUpdateDate { get; set; }

    }
}
