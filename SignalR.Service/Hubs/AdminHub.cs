using Microsoft.AspNetCore.SignalR;

namespace SignalR.Service.Hubs
{ 
    public class AdminHub : Hub
    {
        public async Task SendJobStatus(string message)
        {
            await Clients.Caller.SendAsync("ReceivedMessage",message);
        }
    }
}
