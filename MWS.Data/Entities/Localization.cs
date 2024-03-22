using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Data.Entities
{
    public partial class Localization
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal? localizeId { get; set; }
        public decimal? parentLocalizeId { get; set; }
        public decimal? languageId { get; set; }

        public string? keyName { get; set; }
        public string? value { get; set; }

        //public string? createdBy { get; set; }

        //public DateTime? creationDate { get; set; }

        //public string? lastUpdateBy { get; set; }

        //public DateTime? lastUpdateDate { get; set; }

    }
}
