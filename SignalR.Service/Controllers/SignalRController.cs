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


        [HttpPost("{message}")]
        public void Post(string message)
        {
            _hubContext.Clients.All.SendAsync("publicMessageMethodName", message);
        }

        /// <summary>
        /// Send message to specific client
        /// </summary>
        /// <param name="connectionId"></param>
        /// <param name="message"></param>
        [HttpPost("{connectionId}/{message}")]
        public void Post(string connectionId, string message)
        {
            _hubContext.Clients.Client(connectionId).SendAsync("privateMessageMethodName", message);
        }
    }
}
