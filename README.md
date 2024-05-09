para realizar os envios da nensagem basta utilizar o seguinte metodos

public class NotificRepository : INotificRepository
{
    private static HubConnection _hubConnection;

     public NotificRepository()
    {
        _hubConnection =  new HubConnectionBuilder()
                        .WithUrl("https://localhost:7150/notific")
                        .Build();
    }

    public async Task SendMessageAllClients(string user, string message)
    {
        if (_hubConnection.State == HubConnectionState.Disconnected)
        {
            await _hubConnection.StartAsync();
        }
        await _hubConnection.InvokeAsync("SendMessage", user, message);
    }

    public async Task SendMessageUser(string userId, string message)
    {
        if (_hubConnection.State == HubConnectionState.Disconnected)
        {
            await _hubConnection.StartAsync();
        }
        await _hubConnection.InvokeAsync("SendMessageToUser", userId, message);
    }
}
para ler tem que executar o 


_hubConnection.On()
