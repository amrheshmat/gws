using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class NotificationsController : ControllerBase
{
    private readonly PushNotificationService _pushNotificationService;

    public NotificationsController(PushNotificationService pushNotificationService)
    {
        _pushNotificationService = pushNotificationService;
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendNotification([FromBody] NotificationRequest request)
    {
        // Send notification to the device
        await _pushNotificationService.SendPushNotificationAsync(request.DeviceToken, request.Title, request.Body);
        return Ok("Notification sent successfully.");
    }
}

public class NotificationRequest
{
    public string? DeviceToken { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }
}
