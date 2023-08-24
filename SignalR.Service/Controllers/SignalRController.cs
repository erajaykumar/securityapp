using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace SignalR.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignalRController : Controller
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public SignalRController(IHubContext<NotificationHub> hubcontext)
        {
            _hubContext = hubcontext;
        }


        [HttpPost("send/{userId}")]
        public async Task<IActionResult> SendNotificationToUser(string userId, [FromBody] string message)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(message))
            {
                return BadRequest("UserId and message cannot be empty.");
            }

            await _hubContext.Clients.Group(userId).SendAsync("ReceiveNotification", message);
            return Ok($"Notification sent to user {userId}.");
        }
    }
}
