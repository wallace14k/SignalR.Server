namespace SignalR.Server.Interfaces
{
    public interface INotificHub
    {
        Task ReceiveMessage(string user, string message);
    }
}
