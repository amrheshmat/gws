using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Data.Entities
{
	public partial class TourAdditionalActivity
	{
		[Key, Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int? id { get; set; }

		public int? tourId { get; set; }
		public int? activityId { get; set; }
	}
}
