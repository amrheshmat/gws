using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class NotificationsController : ControllerBase
{

    public NotificationsController()
    {
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendNotification([FromBody] NotificationRequest request)
    {
        // Send notification to the device
        string accessToken = await FirebaseAuth.GetAccessTokenAsync();
        await PushNotificationService.SendPushNotificationAsync(accessToken, request.DeviceToken,request.Title,request.Body);
        return Ok("Notification sent successfully.");
    }
    [HttpGet("getToken")]
    public async Task<string> getToken()
    {
        // Send notification to the device
        string accessToken = await FirebaseAuth.GetAccessTokenAsync();
        return accessToken;
    }
}
public class NotificationRequest
{
    public string? DeviceToken { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }
}
