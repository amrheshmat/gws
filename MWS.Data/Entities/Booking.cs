using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Data.Entities
{
	public partial class Booking
	{
		[Key, Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public decimal? requestId { get; set; }

		public decimal? tourId { get; set; }
		public string? phone { get; set; }
		public string? email { get; set; }
		public string? name { get; set; }
		public string? status { get; set; }
		public string? countryName { get; set; }
		public string? languageName { get; set; }
		public string? pickup { get; set; }
		public DateTime? tourDate { get; set; }
		//public int? hotelTypeId { get; set; }
		public int? numberOfAdult { get; set; }
		public int? numberOfChild { get; set; }
		public int? numberOfInfant { get; set; }
		// List<HotelRoomPricing>? hotelRooms { get; set; }
		public int? numberOfRoom { get; set; }
		//public int? numberOfDoubleRoom { get; set; }
		//public int? numberOfTripleRoom { get; set; }

		//public string? createdBy { get; set; }

		//public DateTime? creationDate { get; set; }

		//public string? lastUpdateBy { get; set; }

		//public DateTime? lastUpdateDate { get; set; }

	}
}
