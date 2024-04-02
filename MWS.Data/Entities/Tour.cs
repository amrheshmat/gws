using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Data.Entities
{
    public partial class Tour
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal? tourId { get; set; }

        public string? title { get; set; }
        public string? duration { get; set; }
        public string? tourLocation { get; set; }
        public string? tourDays { get; set; }
        public string? pickupLocation { get; set; }
        public string? dropOff { get; set; }
        public string? tourType { get; set; }
        public string? overview { get; set; }
        public decimal? includeId { get; set; }
        public decimal? exculdeId { get; set; }
        public string? highlights { get; set; }
        public decimal? expectId { get; set; }
        public decimal? packId { get; set; }
        public decimal? adultPrice { get; set; }
        public decimal? childPrice { get; set; }
        public decimal? infantPrice { get; set; }
        public decimal? capacity { get; set; }
        public int? languageId { get; set; }

        //public string? createdBy { get; set; }

        //public DateTime? creationDate { get; set; }

        //public string? lastUpdateBy { get; set; }

        //public DateTime? lastUpdateDate { get; set; }

    }
}
