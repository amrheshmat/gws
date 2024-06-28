using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Data.Entities
{
    public partial class TourLanguage
    {

        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? tourLanguageId { get; set; }
        public int? languageId { get; set; }

        public int? tourId { get; set; }
        public string? languageName { get; set; }


    }
}
