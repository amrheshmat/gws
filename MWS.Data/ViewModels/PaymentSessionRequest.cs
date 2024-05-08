namespace MWS.Data.ViewModels
{
	public class PaymentSessionRequest
	{
		public string? apiOperation { get; set; }
		public Interaction? interaction { get; set; }
		public Order? order { get; set; }
	}
	public class Interaction
	{
		public string? operation { get; set; }
		public Merchant? merchant { get; set; }
		public Order? order { get; set; }
		public DisplayControl? displayControl { get; set; }
	}
	public class Merchant
	{
		public string? name { get; set; }
	}
	public class DisplayControl
	{
		public string? billingAddress { get; set; }
		public string? customerEmail { get; set; }
		public string? shipping { get; set; }
	}
	public class Order
	{
		public string? currency { get; set; }
		public string? amount { get; set; }
		public string? id { get; set; }
		public string? description { get; set; }
	}
}
