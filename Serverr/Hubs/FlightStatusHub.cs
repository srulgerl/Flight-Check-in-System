using Microsoft.AspNetCore.SignalR;

public class FlightStatusHub : Hub
{
    public override Task OnConnectedAsync() => base.OnConnectedAsync();
    public override Task OnDisconnectedAsync(Exception? ex) => base.OnDisconnectedAsync(ex);
}
