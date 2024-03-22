using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Data.Entities
{
    public partial class Language
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal? languageId { get; set; }

        public string? languageName { get; set; }
        public string? code { get; set; }

        public string? createdBy { get; set; }

        public DateTime? creationDate { get; set; }

        //public string? lastUpdateBy { get; set; }

        //public DateTime? lastUpdateDate { get; set; }

    }
}
