using Microsoft.AspNetCore.Http;

namespace MWS.Data.Entities
{
	public class MailRequest
	{
		public List<string>? ToEmail { get; set; }
		public string? Subject { get; set; }
		public string? Body { get; set; }
		public string? tourName { get; set; }
		public Contact? Contact { get; set; }
		public SpecialRequest? spcialRequest { get; set; }
		public Booking? booking { get; set; }
		public List<IFormFile>? Attachments { get; set; }
	}
}
