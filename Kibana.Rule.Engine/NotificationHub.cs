using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Nest;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kibana.Rule.Engine
{
    [Authorize]
    public class NotificationHub : Hub
    {
       public async Task SendMessage(string userid, string message)
        {
          await  Clients.Users(userid).SendAsync("clientmessage",userid,message);        
           
        }

       
        //public override Task OnDisconnectedAsync(Exception exception)
        //{
        //    var connectionId = Context.ConnectionId;
        //    return base.OnDisconnectedAsync(exception);
        //}
    }
}
