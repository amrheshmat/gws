using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MimeKit;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;
using TripBusiness.Ibusiness;

namespace TripBusiness.business
{
	public class MailService : IMailService
	{
		private ILocalizationService _localizationService;
		private IRepository _repo;
		private readonly MailSettings _mailSettings;
		public MailService(IRepositoryFactory repo, IOptions<MailSettings> mailSettings, ILocalizationService localizationService)
		{
			_repo = repo.Create("AGGRDB");
			_mailSettings = mailSettings.Value;
			_localizationService = localizationService;
		}
		public async Task SendBookEmailAsync(MailRequest mailRequest)
		{
			var email = new MimeMessage();
			email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
			List<InternetAddress> internetAddresses = new List<InternetAddress>();
			if (mailRequest.ToEmail.Where(e => e == _mailSettings.Mail).Count() <= 0)
				mailRequest.ToEmail.Add(_mailSettings.Mail);
			//mailRequest.ToEmail.Add("amrheshmat95@gmail.com");
			foreach (var item in mailRequest.ToEmail)
			{
				var t = MailboxAddress.Parse(item);
				internetAddresses.Add(t);
			}

			email.To.AddRange(internetAddresses);

			email.Subject = mailRequest.Subject == null ? "Booking Request" : mailRequest.Subject;

			var builder = new BodyBuilder();
			builder.HtmlBody = "<!DOCTYPE html> <html><head><style>" +
                ".container{width:50%;margin:auto} .im {color: #000000 !important;}" +
				".header{background: #0f172a; color: #fff; border: 1px solid #eee;padding:10px 15px}" +
				".body{border: 1px solid#eee;line-height:2;padding: 0px 15px;}" +
				".body p{padding: 0px 20px;}" +
				".footer {border: 1px solid #eee; padding: 10px 15px; background: #0f172a;}" +
				".footer p{margin: 0px 20%; color: #fff;}" +
				".im {color:#000 !important;}" +
				"@media only screen and (max-width: 600px){.container{width:100%}}" +
				"</style></head><body>" +
				"<div class='container header' style ='color:red>" +
				"<div class='container'><a style='margin: auto; width: 50px; display: block;' href='https://anoushdahabiya.com'><img style='width:65px;height: 65px;' src='https://anoushdahabiya.com/images/logo-white.png'></a></div>" +
				"<div class='container body'>" +
				"Thanks for booking with us.<br>"+
				"Your booking is confirmed and below is your booking details:<br>"+
				"Name:" + mailRequest.booking.name + "<br>" +
				"Email:" + mailRequest.booking.email + "<br>" +
				"Country:" + mailRequest.booking.countryName + "<br>" +
				"Phone:" + mailRequest.booking.phone + "<br>" +
				"Tour name:" + mailRequest.tourName + "<br>" +
				"No of adults:" + mailRequest.booking.numberOfAdult + "<br>"+
				"No of child:" + mailRequest.booking.numberOfChild + "<br>" +
                "No of inf:" + mailRequest.booking.numberOfInfant + "<br>" +
                "Arrival date:" + mailRequest.booking.tourDate.Value.ToString("dd-MM-yyy") + "<br>" +
                "Tour language:" + mailRequest.booking.languageName + "<br>" +
                "Pick up details:" + mailRequest.booking.pickup + "<br>" +
				"Room type:" + mailRequest.booking.roomType + "<br>" +
                "Payment amount:"+mailRequest.booking.totalPrice + "<br>" +
                "Additional activities:" + mailRequest.additionalActivities + "<br>" +
				"Booking reference no:"+ mailRequest.booking.requestId + "<br>" +

                "One of our team will contact you soon.<br>" +

				"Have a nice trip <br>"+
				"Anoush Dahabiya <br>"+
				"booking@anoushdahabiya.com <br>"+
				"+201061046797" +
				"</div>" +
				"<div class='container footer'> " +
			   "<p>Copy right@<a href='https://anoushdahabiya.com'>anoushdahabiya</a></p>" +
				"</div>" +
				"</div></body</html>";
			if (mailRequest.Attachments != null)
			{
				byte[] fileBytes;
				foreach (var file in mailRequest.Attachments)
				{
					if (file.Length > 0)
					{
						using (var ms = new MemoryStream())
						{
							file.CopyTo(ms);
							fileBytes = ms.ToArray();
						}
						builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
					}
				}
			}
			//builder.HtmlBody = mailRequest.Body;
			email.Body = builder.ToMessageBody();
			builder.TextBody = "This is some plain text";
			using var smtp = new MailKit.Net.Smtp.SmtpClient();
			smtp.Connect("smtp.gmail.com", 587, false);
			//smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
			//search about App passwords in gmail setting to set new app and password
			smtp.Authenticate(email.Sender.ToString(), _mailSettings.Password);
			await smtp.SendAsync(email);
			smtp.Disconnect(true);
		}
		public async Task SendSpecialEmailAsync(MailRequest mailRequest)
		{
			var email = new MimeMessage();
			email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
			List<InternetAddress> internetAddresses = new List<InternetAddress>();
            if (mailRequest.ToEmail.Where(e => e == _mailSettings.Mail).Count() <= 0)
                mailRequest.ToEmail.Add(_mailSettings.Mail);
			//mailRequest.ToEmail.Add("amrheshmat95@gmail.com");

            foreach (var item in mailRequest.ToEmail)
			{
				var t = MailboxAddress.Parse(item);
				internetAddresses.Add(t);
			}
			email.To.AddRange(internetAddresses);

			email.Subject = mailRequest.Subject;

			var builder = new BodyBuilder();
			builder.HtmlBody = "<!DOCTYPE html> <html><head><style>" +
                ".container{width:50%;margin:auto} .im {color: #000000 !important;}" +
				".header{background: #0f172a; color: #fff; border: 1px solid #eee;padding:10px 15px}" +
				".body{border: 1px solid#eee;line-height:2;padding: 0px 15px;}" +
				".body p{padding: 0px 20px;}" +
				".footer {border: 1px solid #eee; padding: 10px 15px; background: #0f172a;}" +
				".footer p{margin: 0px 20%; color: #fff;}" +
				".im {color:#000 !important;}" +
				"@media only screen and (max-width: 600px){.container{width:100%}}" +
                "</style></head><body>" +
				"<div class='container header' style ='color:red>" +
				"<div class='container'><a style='margin: auto; width: 50px; display: block;' href='https://anoushdahabiya.com'><img style='width:65px;height: 65px;' src='https://anoushdahabiya.com/images/logo-white.png'></a></div>" +
				"<div class='container body'>"+
				"Name:" + mailRequest.spcialRequest?.name + "<br>" +
				"Email:" + mailRequest.spcialRequest?.email + "<br>" +
				"Phone:" + mailRequest.spcialRequest?.phone + "<br>" +
				"Number Of Adult:" + mailRequest.spcialRequest?.numberOfAdult + "<br>" +
				"Number Of Child:" + mailRequest.spcialRequest?.numberOfChild + "<br>" +
				"Number Of Infant:" + mailRequest.spcialRequest?.numberOfInfant + "<br>" +
				"Message:" + mailRequest.spcialRequest?.message + "<br>" +
				"Arrival date:" + mailRequest.spcialRequest?.arriveDate.Value.ToString("dd-MM-yyy") + "<br>" +
				"Leave date:" + mailRequest.spcialRequest?.leaveDate.Value.ToString("dd-MM-yyy") + "<br>" +
				"Nationality:" + mailRequest.spcialRequest?.countryName + "<br>" +
				"</div>" +
				"<div class='container footer'> " +
			   "<p>Copy right@<a href='https://anoushdahabiya.com'>anoushdahabiya</a></p>" +
				"</div>" +
				"</div></body</html>";
			if (mailRequest.Attachments != null)
			{
				byte[] fileBytes;
				foreach (var file in mailRequest.Attachments)
				{
					if (file.Length > 0)
					{
						using (var ms = new MemoryStream())
						{
							file.CopyTo(ms);
							fileBytes = ms.ToArray();
						}
						builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
					}
				}
			}
			//builder.HtmlBody = mailRequest.Body;
			email.Body = builder.ToMessageBody();
			builder.TextBody = "This is some plain text";
			using var smtp = new MailKit.Net.Smtp.SmtpClient();
			smtp.Connect("smtp.gmail.com", 587, false);
			//smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
			//search about App passwords in gmail setting to set new app and password
			smtp.Authenticate(email.Sender.ToString(), _mailSettings.Password);
			await smtp.SendAsync(email);
			smtp.Disconnect(true);
		}
		public async Task SendContactEmailAsync(MailRequest mailRequest)
		{
			List<Setting> settings = await _repo.GetAll<Setting>().ToListAsync();
			var facebook = settings.Where(e => e.keyName == "facebook").FirstOrDefault()?.value;
			var instgram = settings.Where(e => e.keyName == "instgram").FirstOrDefault()?.value;
			var youtube = settings.Where(e => e.keyName == "youtube").FirstOrDefault()?.value;
			var twitter = settings.Where(e => e.keyName == "twitter").FirstOrDefault()?.value;
			var email = new MimeMessage();
			email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
			List<InternetAddress> internetAddresses = new List<InternetAddress>();
            if (mailRequest.ToEmail.Where(e => e == _mailSettings.Mail).Count() <= 0)
                mailRequest.ToEmail.Add(_mailSettings.Mail);
			//mailRequest.ToEmail.Add("amrheshmat95@gmail.com");
            foreach (var item in mailRequest.ToEmail)
            {
				var t = MailboxAddress.Parse(item);
				internetAddresses.Add(t);
			}
			email.To.AddRange(internetAddresses);

			email.Subject = mailRequest.Subject;

			var builder = new BodyBuilder();
			builder.HtmlBody = "<!DOCTYPE html> <html><head><style>" +
                ".container{width:50%;margin:auto} .im {color: #000000 !important;}" +
				".header{background: #0f172a; color: #fff; border: 1px solid #eee;padding:10px 15px}" +
				".body{border: 1px solid#eee;line-height:2;padding: 0px 15px;}" +
				".body p{padding: 0px 20px;}" +
				".footer {border: 1px solid#eee; padding: 10px 15px; background: #0f172a;}" +
				".footer p{margin: 0px 20%; color: #fff;}" +
				".im {color:#000 !important;}" +
				"@media only screen and (max-width: 600px){.container{width:100%}}" +
                "</style></head><body>" +
				"<div class='container header' style ='color:red>" +
				"<div class='container'><a style='margin: auto; width: 50px; display: block;' href='https://anoushdahabiya.com'><img style='width:65px;height: 65px;' src='https://anoushdahabiya.com/images/logo-white.png'></a></div>" +
				"<div class='container body'>"+
				"Name:" + mailRequest.spcialRequest?.name + "<br>" +
				"Email:" + mailRequest.spcialRequest?.email + "<br>" +
				"Phone:" + mailRequest.spcialRequest?.phone + "<br>" +
				"Number Of Adult:" + mailRequest.spcialRequest?.numberOfAdult + "<br>" +
				"Number Of Child:" + mailRequest.spcialRequest?.numberOfChild + "<br>" +
				"Number Of Infant:" + mailRequest.spcialRequest?.numberOfInfant + "<br>" +
				"Message:" + mailRequest.spcialRequest?.message + "<br>" +
				"</div>" +
				"<div class='container footer'>" +
				"<p>Copy right@<a href='https://anoushdahabiya.com'>anoushdahabiya</a></p>" +
				"</div>" +
				"</div></body</html>";
			if (mailRequest.Attachments != null)
			{
				byte[] fileBytes;
				foreach (var file in mailRequest.Attachments)
				{
					if (file.Length > 0)
					{
						using (var ms = new MemoryStream())
						{
							file.CopyTo(ms);
							fileBytes = ms.ToArray();
						}
						builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
					}
				}
			}
			//builder.HtmlBody = mailRequest.Body;
			email.Body = builder.ToMessageBody();
			builder.TextBody = "This is some plain text";
			using var smtp = new MailKit.Net.Smtp.SmtpClient();
			smtp.Connect("smtp.gmail.com", 587, false);
			//smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
			//search about App passwords in gmail setting to set new app and password
			smtp.Authenticate(email.Sender.ToString(), _mailSettings.Password);
			await smtp.SendAsync(email);
			smtp.Disconnect(true);
		}
		public async Task SendContactThankEmailAsync(MailRequest mailRequest)
		{

			var email = new MimeMessage();
			email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
			List<InternetAddress> internetAddresses = new List<InternetAddress>();
			foreach (var item in mailRequest.ToEmail)
			{
				var t = MailboxAddress.Parse(item);
				internetAddresses.Add(t);
			}
			email.To.AddRange(internetAddresses);

			email.Subject = mailRequest.Subject;

			var builder = new BodyBuilder();
			builder.HtmlBody = "<!DOCTYPE html> <html><head><style>" +
                ".container{width:50%;margin:auto} .im {color: #000000 !important;}" +
				".header{background: #0f172a; color: #fff; border: 1px solid #eee;padding:10px 15px}" +
				".body{border: 1px solid#eee;line-height:2;padding: 0px 15px;}" +
				".body p{padding: 0px 20px;}" +
				".footer {border: 1px solid#eee; padding: 10px 15px; background: #0f172a;}" +
				".footer p{margin: 0px 20%; color: #fff;}" +
				".im {color:#000 !important;}" +
				"@media only screen and (max-width: 600px){.container{width:100%}}" +
                "</style></head><body>" +
				"<div class='container header' style ='color:red>" +
				"<div class='container'><a style='margin: auto; width: 50px; display: block;' href='https://anoushdahabiya.com'><img style='width:65px;height: 65px;' src='https://anoushdahabiya.com/images/logo-white.png'></a></div>" +
				"<div class='container body'>" +
				"<p> <b>" + _localizationService.Localize("Dear") + "</b></p><p> " + mailRequest.Contact?.message + "</p>" +
				"</div>" +
				"<div class='container footer'>" +
				"<p>Copy right@<a href='https://anoushdahabiya.com'>anoushdahabiya</a></p>" +
				"</div>" +
				"</div></body</html>";
			if (mailRequest.Attachments != null)
			{
				byte[] fileBytes;
				foreach (var file in mailRequest.Attachments)
				{
					if (file.Length > 0)
					{
						using (var ms = new MemoryStream())
						{
							file.CopyTo(ms);
							fileBytes = ms.ToArray();
						}
						builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
					}
				}
			}
			//builder.HtmlBody = mailRequest.Body;
			email.Body = builder.ToMessageBody();
			builder.TextBody = "This is some plain text";
			using var smtp = new MailKit.Net.Smtp.SmtpClient();
			smtp.Connect("smtp.gmail.com", 587, false);
            //smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            //search about App passwords in gmail setting to set new app and password
            smtp.Authenticate(email.Sender.ToString(), _mailSettings.Password);
			await smtp.SendAsync(email);
			smtp.Disconnect(true);
		}
		public async Task SendSpecialThankEmailAsync(MailRequest mailRequest)
		{
			//List<Setting> settings = await _repo.GetAll<Setting>().ToListAsync();
			//var facebook = settings.Where(e => e.keyName == "facebook").FirstOrDefault()?.value;
			//var instgram = settings.Where(e => e.keyName == "instgram").FirstOrDefault()?.value;
			//var youtube = settings.Where(e => e.keyName == "youtube").FirstOrDefault()?.value;
			//var twitter = settings.Where(e => e.keyName == "twitter").FirstOrDefault()?.value;

			var email = new MimeMessage();
			email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
			List<InternetAddress> internetAddresses = new List<InternetAddress>();
			foreach (var item in mailRequest.ToEmail)
			{
				var t = MailboxAddress.Parse(item);
				internetAddresses.Add(t);
			}
			email.To.AddRange(internetAddresses);

			email.Subject = mailRequest.Subject;

			var builder = new BodyBuilder();
			builder.HtmlBody = "<!DOCTYPE html> <html><head><style>" +
                ".container{width:50%;margin:auto} .im {color: #000000 !important;}" +
				".header{background: #0f172a; color: #fff; border: 1px solid #eee;padding:10px 15px}" +
				".body{border: 1px solid #eee;line-height:2;padding: 0px 15px;}" +
				".body p{padding: 0px 20px;}" +
				".footer {border: 1px solid #eee; padding: 10px 15px; background: #0f172a;}" +
				".footer p{margin: 0px 20%; color: #fff;}" +
				".im {color:#000 !important;}" +
				"@media only screen and (max-width: 600px){.container{width:100%}}" +
                "</style></head><body>" +
				"<div class='container header' style ='color:red>" +
				"<div class='container'><a style='margin: auto; width: 50px; display: block;' href='https://anoushdahabiya.com'><img style='width:65px;height: 65px;' src='https://anoushdahabiya.com/images/logo-white.png'></a></div>" +
				"<div class='container body'>" +
				"<p> <b>" + _localizationService.Localize("Dear") + "</b></p><p> " + mailRequest.spcialRequest?.message + "</p>" +
				"</div>" +
				"<div class='container footer'> " +
				"<p>Copy right@<a href='https://anoushdahabiya.com'>anoushdahabiya</a></p>" +
				"</div>" +
				"</div></body</html>";
			if (mailRequest.Attachments != null)
			{
				byte[] fileBytes;
				foreach (var file in mailRequest.Attachments)
				{
					if (file.Length > 0)
					{
						using (var ms = new MemoryStream())
						{
							file.CopyTo(ms);
							fileBytes = ms.ToArray();
						}
						builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
					}
				}
			}
			//builder.HtmlBody = mailRequest.Body;
			email.Body = builder.ToMessageBody();
			builder.TextBody = "This is some plain text";
			using var smtp = new MailKit.Net.Smtp.SmtpClient();
			smtp.Connect("smtp.gmail.com", 587, false);
			//smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
			//search about App passwords in gmail setting to set new app and password
			smtp.Authenticate(email.Sender.ToString(), _mailSettings.Password);
			await smtp.SendAsync(email);
			smtp.Disconnect(true);
		}
		public async Task SendBookThanksEmailAsync(MailRequest mailRequest)
		{
			var email = new MimeMessage();
			email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
			List<InternetAddress> internetAddresses = new List<InternetAddress>();
			foreach (var item in mailRequest.ToEmail)
			{
				var t = MailboxAddress.Parse(item);
				internetAddresses.Add(t);
			}
			email.To.AddRange(internetAddresses);
			email.Subject = mailRequest.Subject;
			var builder = new BodyBuilder();
			builder.HtmlBody = "<!DOCTYPE html> <html><head><style>" +
                ".container{width:50%;margin:auto} .im {color: #000000 !important;}" +
				".header{background: #0f172a; color: #fff; border: 1px solid #eee;padding:10px 15px}" +
				".body{border: 1px solid#eee;line-height:2;padding: 0px 15px;}" +
				".body p{padding: 0px 20px;}" +
				".footer {border: 1px solid #eee; padding: 10px 15px; background: #0f172a;}" +
				".footer p{margin: 0px 20%; color: #fff;}" +
				".im {color:#000 !important;}" +
				"@media only screen and (max-width: 600px){.container{width:100%}}" +
				"</style></head><body>" +
				"<div class='container header' style ='color:red>" +
				"<div class='container'><a style='margin: auto; width: 50px; display: block;' href='https://anoushdahabiya.com'><img style='width:65px;height: 65px;' src='https://anoushdahabiya.com/images/logo-white.png'></a></div>" +
				"<div class='container body'>" +
				"Thanks for booking with us.<br>" +
				"Your booking is confirmed and below is your booking details:<br>" +
				"Name:" + mailRequest.booking.name + "<br>" +
				"Email:" + mailRequest.booking.email + "<br>" +
				"Country:" + mailRequest.booking.countryName + "<br>" +
				"Phone:" + mailRequest.booking.phone + "<br>" +
				"Tour name:" + mailRequest.tourName + "<br>" +
				"No of adults:" + mailRequest.booking.numberOfAdult + "<br>" +
				"No of child:" + mailRequest.booking.numberOfChild + "<br>" +
				"No of inf:" + mailRequest.booking.numberOfInfant + "<br>" +
				"Arrival date:" + mailRequest.booking.tourDate.Value.ToString("dd-MM-yyy") + "<br>" +
				"Tour language:" + mailRequest.booking.languageName + "<br>" +
				"Pick up details:" + mailRequest.booking.pickup + "<br>" +
				"Room type:" + mailRequest.booking.roomType + "<br>" +
				"Payment amount:" + mailRequest.booking.totalPrice + "<br>" +
				"Additional activities:" + mailRequest.additionalActivities + "<br>" +
				"Booking reference no:" + mailRequest.booking.requestId + "<br>" +

				"One of our team will contact you soon.<br>" +

				"Have a nice trip <br>" +
				"Anoush Dahabiya <br>" +
				"booking@anoushdahabiya.com <br>" +
				"+201061046797" +
				"</div>" +
				"<div class='container footer'> " +
			   "<p>Copy right@<a href='https://anoushdahabiya.com'>anoushdahabiya</a></p>" +
				"</div>" +
				"</div></body</html>";
			if (mailRequest.Attachments != null)
			{
				byte[] fileBytes;
				foreach (var file in mailRequest.Attachments)
				{
					if (file.Length > 0)
					{
						using (var ms = new MemoryStream())
						{
							file.CopyTo(ms);
							fileBytes = ms.ToArray();
						}
						builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
					}
				}
			}
			//builder.HtmlBody = mailRequest.Body;
			email.Body = builder.ToMessageBody();
			builder.TextBody = "This is some plain text";
			using var smtp = new MailKit.Net.Smtp.SmtpClient();
			smtp.Connect("smtp.gmail.com", 587, false);
			//smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
			//search about App passwords in gmail setting to set new app and password
			smtp.Authenticate(email.Sender.ToString(), _mailSettings.Password);
			await smtp.SendAsync(email);
			smtp.Disconnect(true);
		}
	}
}

