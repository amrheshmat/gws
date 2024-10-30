using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MWS.Data.Entities
{
    public partial class Blog
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? blogId { get; set; }
        public string? seoTitle { get; set; }
        public string? seoDescription { get; set; }
        public string? seokeyWords { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public int? languageId { get; set; }
        public DateTime? creationDate { get; set; }
    }
}
