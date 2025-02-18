using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class PushNotificationService
{
    private static readonly string FcmUrl = "https://fcm.googleapis.com/v1/projects/gws-core-399b1/messages:send";

    public static async Task SendPushNotificationAsync(string accessToken, string deviceToken, string titleValue, string bodyValue)
    {
        var notification = new
        {
            message = new
            {
                token = deviceToken,  // Device token
                notification = new
                {
                    title = titleValue,  // Notification title
                    body = bodyValue     // Notification body
                }
            }
        };

        var client = new HttpClient();
        var requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://fcm.googleapis.com/v1/projects/gws-core-399b1/messages:send")
        {
            Content = new StringContent(JsonConvert.SerializeObject(notification), Encoding.UTF8, "application/json")
        };

        // Add authorization header
        requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

        var response = await client.SendAsync(requestMessage);
        var responseString = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Notification sent successfully");
        }
        else
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Error sending notification: {response.StatusCode} - {responseContent}");
        }
    }

}
