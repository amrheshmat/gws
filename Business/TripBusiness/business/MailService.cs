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
        public async Task SendSpecialEmailAsync(MailRequest mailRequest)
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
                ".container{width:50%;margin:auto}" +
                ".header{background: #0f172a; color: #fff; border: 1px solid #0f172a;padding:10px 0px}" +
                ".body{border: 1px solid#0f172a;}" +
                ".body p{padding: 0px 20px;}" +
                ".footer {border: 1px solid; padding: 10px 0px; background: #0f172a;}" +
                ".footer p{margin: 0px 30%; color: #fff;}" +
                "@media only screen and (max-width: 600px){.container{width:100%}}" +
                "</style></head><body>" +
                "<div class='container header' style ='color:red>" +
                "<div class='container'><a style='margin: auto; width: 50px; display: block;' href='https://anoushdahabiya.com'><img style='width:65px;height: 65px;' src='https://anoushdahabiya.com/images/logo-white.png'></a></div>" +
                "<div class='container body'> <p> <b>" + _localizationService.Localize("Name") + "</b> : " + mailRequest.spcialRequest?.name + "</p>" +
                "<p> <b>" + _localizationService.Localize("Phone") + "</b> : " + mailRequest.spcialRequest?.phone + "</p>" +
                "<p> <b>" + _localizationService.Localize("NumberOfAdult") + "</b> : " + mailRequest.spcialRequest?.numberOfAdult + "</p>" +
                "<p> <b>" + _localizationService.Localize("NumberOfChild") + "</b> : " + mailRequest.spcialRequest?.numberOfChild + "</p>" +
                "<p> <b>" + _localizationService.Localize("NumberOfInfant") + "</b> : " + mailRequest.spcialRequest?.numberOfInfant + "</p>" +
                "<p> <b>" + _localizationService.Localize("Message") + "</b> : " + mailRequest.spcialRequest?.message + "</p>" +
                "</div>" +
                "<div class='container footer'> " +
               "<p>Copy right@<a href='https://anoushdahabiya.com'>anoushdahabiya</a></p>" +
                "</div>" +
                "</div></body</html>";
            //using (StreamReader SourceReader = System.IO.File.OpenText(path to your file))
            //{
            //    builder.HtmlBody = SourceReader.ReadToEnd();
            //}
            //builder.Attachments.Add(@"https://localhost:7254/images/about.jpg");
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
            //this password generated beacuse my mail use two factor authentication
            smtp.Authenticate("amrheshmat95@gmail.com", "xgps axfo etqm sqsz");
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
            foreach (var item in mailRequest.ToEmail)
            {
                var t = MailboxAddress.Parse(item);
                internetAddresses.Add(t);
            }
            email.To.AddRange(internetAddresses);

            email.Subject = mailRequest.Subject;

            var builder = new BodyBuilder();
            builder.HtmlBody = "<!DOCTYPE html> <html><head><style>" +
                ".container{width:50%;margin:auto}" +
                ".header{background: #0f172a; color: #fff; border: 1px solid #0f172a;padding:10px 0px}" +
                ".body{border: 1px solid#0f172a;}" +
                ".body p{padding: 0px 20px;}" +
                ".footer {border: 1px solid; padding: 10px 0px; background: #0f172a;}" +
                ".footer p{margin: 0px 30%; color: #fff;}" +
                "@media only screen and (max-width: 600px){.container{width:100%}}" +
                "</style></head><body>" +
                "<div class='container header' style ='color:red>" +
                "<div class='container'><a style='margin: auto; width: 50px; display: block;' href='https://anoushdahabiya.com'><img style='width:65px;height: 65px;' src='https://anoushdahabiya.com/images/logo-white.png'></a></div>" +
                "<div class='container body'> <p> <b>Name</b> : " + mailRequest.Contact?.name + "</p>" +
                "<p> <b>Phone</b> : " + mailRequest.Contact?.phone + "</p>" +
                "<p> <b>Number Of Adult</b> : " + mailRequest.Contact?.numberOfAdult + "</p>" +
                "<p> <b>Number Of Child</b> : " + mailRequest.Contact?.numberOfChild + "</p>" +
                "<p> <b>Number Of Infant</b> : " + mailRequest.Contact?.numberOfInfant + "</p>" +
                "<p> <b>Message</b> : " + mailRequest.Contact?.message + "</p>" +
                "</div>" +
                "<div class='container footer'>" +
                "<p>Copy right@<a href='https://anoushdahabiya.com'>anoushdahabiya</a></p>" +
                "</div>" +
                "</div></body</html>";
            //using (StreamReader SourceReader = System.IO.File.OpenText(path to your file))
            //{
            //    builder.HtmlBody = SourceReader.ReadToEnd();
            //}
            //builder.Attachments.Add(@"https://localhost:7254/images/about.jpg");
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
            //this password generated beacuse my mail use two factor authentication
            smtp.Authenticate("amrheshmat95@gmail.com", "xgps axfo etqm sqsz");
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
                ".container{width:50%;margin:auto}" +
                ".header{background: #0f172a; color: #fff; border: 1px solid #0f172a;padding:10px 0px}" +
                ".body{border: 1px solid#0f172a;}" +
                ".body p{padding: 0px 20px;}" +
                ".footer {border: 1px solid; padding: 10px 0px; background: #0f172a;}" +
                ".footer p{margin: 0px 30%; color: #fff;}" +
                "@media only screen and (max-width: 600px){.container{width:100%}}" +
                "</style></head><body>" +
                "<div class='container header' style ='color:red>" +
                "<div class='container'><a style='margin: auto; width: 50px; display: block;' href='https://anoushdahabiya.com'><img style='width:65px;height: 65px;' src='https://anoushdahabiya.com/images/logo-white.png'></a></div>" +
                "<div class='container body'>" +
                "<p> <b>" + _localizationService.Localize("Dear") + " " + mailRequest.Contact?.name + "</b> ,</p><p> " + mailRequest.Contact?.message + "</p>" +
                "</div>" +
                "<div class='container footer'>" +
                "<p>Copy right@<a href='https://anoushdahabiya.com'>anoushdahabiya</a></p>" +
                "</div>" +
                "</div></body</html>";
            //using (StreamReader SourceReader = System.IO.File.OpenText(path to your file))
            //{
            //    builder.HtmlBody = SourceReader.ReadToEnd();
            //}
            //builder.Attachments.Add(@"https://localhost:7254/images/about.jpg");
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
            //this password generated beacuse my mail use two factor authentication
            smtp.Authenticate("amrheshmat95@gmail.com", "xgps axfo etqm sqsz");
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
                ".container{width:50%;margin:auto}" +
                ".header{background: #0f172a; color: #fff; border: 1px solid #0f172a;padding:10px 0px}" +
                ".body{border: 1px solid#0f172a;}" +
                ".body p{padding: 0px 20px;}" +
                ".footer {border: 1px solid; padding: 10px 0px; background: #0f172a;}" +
                ".footer p{margin: 0px 30%; color: #fff;}" +
                "@media only screen and (max-width: 600px){.container{width:100%}}" +
                "</style></head><body>" +
                "<div class='container header' style ='color:red>" +
                "<div class='container'><a style='margin: auto; width: 50px; display: block;' href='https://anoushdahabiya.com'><img style='width:65px;height: 65px;' src='https://anoushdahabiya.com/images/logo-white.png'></a></div>" +
                "<div class='container body'>" +
                "<p> <b>" + _localizationService.Localize("Dear") + " " + mailRequest.spcialRequest?.name + "</b> ,</p><p> " + mailRequest.spcialRequest?.message + "</p>" +
                "</div>" +
                "<div class='container footer'> " +
                "<p>Copy right@<a href='https://anoushdahabiya.com'>anoushdahabiya</a></p>" +
                "</div>" +
                "</div></body</html>";
            //using (StreamReader SourceReader = System.IO.File.OpenText(path to your file))
            //{
            //    builder.HtmlBody = SourceReader.ReadToEnd();
            //}
            //builder.Attachments.Add(@"https://localhost:7254/images/about.jpg");
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
            //this password generated beacuse my mail use two factor authentication
            smtp.Authenticate("amrheshmat95@gmail.com", "xgps axfo etqm sqsz");
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}

