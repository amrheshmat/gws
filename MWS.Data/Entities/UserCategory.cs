using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Data.Entities
{
    public partial class UserCategory
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? id { get; set; }
        public int? user_id { get; set; }
        public int? category_id { get; set; }
    }
}
