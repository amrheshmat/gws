using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Data.Entities
{
    public partial class SpecialRequest
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal? specialRequestId { get; set; }

        public string? phone { get; set; }
        public string? email { get; set; }
        public string? name { get; set; }
        public string? countryName { get; set; }
        public string? message { get; set; }
        public DateTime? arriveDate { get; set; }
        public DateTime? leaveDate { get; set; }
        public int? nights { get; set; }
        public int? numberOfAdult { get; set; }
        public int? numberOfChild { get; set; }
        public int? numberOfInfant { get; set; }

        //public string? createdBy { get; set; }

        //public DateTime? creationDate { get; set; }

        //public string? lastUpdateBy { get; set; }

        //public DateTime? lastUpdateDate { get; set; }

    }
}
