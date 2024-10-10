using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Data.Entities
{
    public partial class TourAttachment
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal? tourAttachmentId { get; set; }

        public string? attachmentPath { get; set; }
        public string? attachmentName { get; set; }
        public string? isMainAttachment { get; set; }
        public string? type { get; set; }
        public decimal? tourId { get; set; }
    }
}
