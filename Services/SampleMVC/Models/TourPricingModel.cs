namespace SampleMVC.Models
{
	public class TourPricingModel
	{
		//public HotelType? hotel { get; set; }
		//public RoomType? room { get; set; }
		//public HotelRoomPricing? roomPricing { get; set; }

		public int? hotelRoomId { get; set; }
		public string? hotelTypeName { get; set; }
		//public int? hotelTypeId { get; set; }
		public string? roomTypeName { get; set; }
		public int? roomTypeId { get; set; }
		//public double? price { get; set; }
		public int? numberOfAdult { get; set; }
		public int? numberOfChild { get; set; }
		public int? numberOfInfant { get; set; }
	}
}
