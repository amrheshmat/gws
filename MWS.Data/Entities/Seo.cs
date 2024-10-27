using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MWS.Data.Entities
{
    public partial class Seo
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? seoId { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public string? keyWords { get; set; }
        public string? viewport { get; set; }


    }
}
