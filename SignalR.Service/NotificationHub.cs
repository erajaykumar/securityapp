using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalR.Service
{
    public class NotificationHub : Hub
    {
        private static readonly Dictionary<string, string> UserConnections = new Dictionary<string, string>();

        public override async Task OnConnectedAsync()
        {
            string userId = Context.UserIdentifier;
            string connectionId = Context.ConnectionId;

            if (!string.IsNullOrEmpty(userId))
            {
                if (UserConnections.ContainsKey(userId))
                {
                    UserConnections[userId] = connectionId;
                }
                else
                {
                    UserConnections.Add(userId, connectionId);
                }
            }

            await base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            string userId = Context.UserIdentifier;
            if (!string.IsNullOrEmpty(userId) && UserConnections.ContainsKey(userId))
            {
                UserConnections.Remove(userId);
            }

            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendNotificationToUser(string userId, string message)
        {
            if (UserConnections.ContainsKey(userId))
            {
                string connectionId = UserConnections[userId];
                await Clients.Client(connectionId).SendAsync("ReceiveNotification", message);
            }
        }
    }
}