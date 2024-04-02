using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Data.Entities
{
    public partial class Faq
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? faqId { get; set; }

        public string? question { get; set; }
        public string? answer { get; set; }
        public int? orderId { get; set; }
        public int? languageId { get; set; }
    }
}
