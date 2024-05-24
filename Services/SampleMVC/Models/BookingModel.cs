using SampleMVC.Models;

namespace MWS.Data.Entities
{
	public partial class BookingModel
	{
		public decimal? requestId { get; set; }

		public decimal? tourId { get; set; }
		public string? phone { get; set; }
		public string? email { get; set; }
		public string? name { get; set; }
		public string? status { get; set; }
		public string? countryName { get; set; }
		public string? languageName { get; set; }
		public string? pickup { get; set; }
		public decimal? totalPrice { get; set; }
		public DateTime? tourDate { get; set; }
		//public int? hotelTypeId { get; set; }
		public int? numberOfAdult { get; set; }
		public int? numberOfChild { get; set; }
		public int? numberOfInfant { get; set; }
		public List<RoomCount>? roomCountList { get; set; }
		public List<BookAdditionalActivity>? bookAdditionalActivities { get; set; }
	}
}
