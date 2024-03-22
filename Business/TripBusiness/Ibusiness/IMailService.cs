using MWS.Data.Entities;

namespace TripBusiness.Ibusiness
{
    public interface IMailService
    {
        Task SendContactEmailAsync(MailRequest mailRequest);
        Task SendContactThankEmailAsync(MailRequest mailRequest);
    }
}
