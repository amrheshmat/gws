using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Data.Entities
{
    public partial class WhyChooseUs
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? id { get; set; }

        public string? title { get; set; }
        public int? languageId { get; set; }
    }
}
