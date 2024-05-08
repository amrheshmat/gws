namespace MWS.Data.ViewModels
{
	public class PaymentSession
	{
		public string? checkoutMode { get; set; }
		public string? merchant { get; set; }
		public string? result { get; set; }
		public Session? session { get; set; }
		public string? successIndicator { get; set; }
	}
}
