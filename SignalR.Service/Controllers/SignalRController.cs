using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR.Service.Hubs;
using System.Runtime.CompilerServices;

namespace SignalR.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignalRController : Controller
    {
        private readonly IHubContext<NotificationHub> _hubContext;
        AdminHub adminHub;
        public SignalRController( AdminHub adminHub, IHubContext<NotificationHub> hubcontext)
        {            
                  
            this.adminHub = adminHub;
            _hubContext = hubcontext;
        }


        //[HttpPost("{message}")]
        //public void Post(string message)
        //{
        //    _hubContext.Clients.All.SendAsync("publicMessageMethodName", message);
        //}

        [HttpPost("{msg}")]
        public async void PostMessage(string msg)
        {
            await adminHub.SendJobStatus(msg);
           
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
