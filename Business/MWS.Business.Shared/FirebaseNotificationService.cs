using FirebaseAdmin.Messaging;
using MediatR;
using System.Threading.Tasks;

public class FirebaseNotificationService
{
    private readonly string _firebaseServerKey = "F6Pn3fpUu0-38JAaNuAMu0Vr1XByUnyGh6NEC0XM52E"; // Obtain this from Firebase Console

    public async Task SendPushNotificationAsync(string token, string title, string body)
    {
        var message = new Message
        {
            Token = token,
            Notification = new Notification
            {
                Title = title,
                Body = body
            }
        };

        try
        {
            string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
            Console.WriteLine("Successfully sent message: " + response);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error sending message: " + ex.Message);
        }
    }
}
