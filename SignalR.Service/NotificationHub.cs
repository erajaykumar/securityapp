﻿using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalR.Service
{
    public class NotificationHub : Hub
    {
        public void GetDataFromClient(string userId, string connectionId)
        {
            Clients.Client(connectionId).SendAsync("clientMethodName", $"Updated userid {userId}");
        }

        public override Task OnConnectedAsync()
        {
            var connectionId = Context.ConnectionId;
            Clients.Client(connectionId).SendAsync("WelcomeMethodName", connectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var connectionId = Context.ConnectionId;
            return base.OnDisconnectedAsync(exception);
        }
    }
}
