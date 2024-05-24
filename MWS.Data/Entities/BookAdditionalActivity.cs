using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Data.Entities
{
	public partial class BookAdditionalActivity
	{
		[Key, Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int? id { get; set; }

		public decimal? bookId { get; set; }
		public int? tourActivityId { get; set; }
	}
}
