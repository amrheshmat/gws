using MWS.Data.Entities;

namespace TripBusiness.Ibusiness
{
    public interface IMailService
    {
        Task SendContactEmailAsync(MailRequest mailRequest);
        Task SendContactThankEmailAsync(MailRequest mailRequest);
        Task SendBookEmailAsync(MailRequest mailRequest);
        Task SendSpecialEmailAsync(MailRequest mailRequest);
        Task SendSpecialThankEmailAsync(MailRequest mailRequest);
        Task SendBookThanksEmailAsync(MailRequest mailRequest);
    }
}
