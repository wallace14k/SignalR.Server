using Microsoft.AspNetCore.SignalR;
using SignalR.Server.Interfaces;

namespace SignalR.Server.Hubs
{
    public sealed class NotificHub :Hub<INotificHub>
    {
        public async Task SendMessage(string user, string message) => await Clients.All.ReceiveMessage(user, message);

        public async Task SendMessageToCaller(string user, string message) => await Clients.Caller.ReceiveMessage(user, message);

        public async Task SendMessageToGroup(string user, string message) => await Clients.Group("SignalR Users").ReceiveMessage(user, message);

        public async Task SendMessageToUser(string user, string message) => await Clients.User(user).ReceiveMessage(user, message);

    }
}
