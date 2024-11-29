using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Data.Entities
{
    public partial class FacebookToken
	{
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? id { get; set; }
        public string? appId { get; set; }
        public string? appSecret { get; set; }
        public string? shortToken { get; set; }
        public string? longToken { get; set; }
        public DateTime? expiryDate { get; set; }
    }
}
