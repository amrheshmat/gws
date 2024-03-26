using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Data.Entities
{
	public partial class RoomType
	{
		[Key, Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int? roomTypeId { get; set; }
		public string? roomTypeName { get; set; }
		public string? icon { get; set; }
	}
}
