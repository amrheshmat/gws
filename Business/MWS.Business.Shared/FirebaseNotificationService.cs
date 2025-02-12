using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class PushNotificationService
{
    private readonly HttpClient _httpClient;
    private readonly string _serverKey = "AAAAMV1DFFw:APA91bFuS2gQt6QHO7X8M3AdlKiIJALLG8hT8Hmt7uL0q_gUH9VAVofj-FaLGkJR1j6oZuOradQtZeD6zQrYXFmqAVUKIIz-TykS711asogm-MJlit_JeQJ3qtZyQf9dqSMZdncMDekD"; // Firebase Cloud Messaging server key

    public PushNotificationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task SendPushNotificationAsync(string deviceToken, string title, string body)
    {
        var message = new
        {
            to = deviceToken,  // Firebase Device Token
            notification = new
            {
                title,
                body
            },
            priority = "high"
        };

        var content = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");

        var requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://fcm.googleapis.com/fcm/send")
        {
            Content = content
        };

        // Set Authorization header
        requestMessage.Headers.Add("Authorization", $"key={_serverKey}");

        var response = await _httpClient.SendAsync(requestMessage);

        if (!response.IsSuccessStatusCode)
        {
            var errorMessage = await response.Content.ReadAsStringAsync();
            throw new Exception($"Failed to send notification: {errorMessage}");
        }
    }
}
