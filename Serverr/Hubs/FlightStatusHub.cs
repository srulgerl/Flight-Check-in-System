

using Microsoft.AspNetCore.SignalR;

namespace Web.Server;

public class FlightStatusHub : Hub
{
    public async Task SendFlightStatus(string flightNumber, string status)
    {
        Console.WriteLine($"Flight {flightNumber} status: {status}");
        await Clients.All.SendAsync("ReceiveFlightStatus", flightNumber, status);
    }


    public override async Task OnConnectedAsync()
    {
        await Clients.Caller.SendAsync("ReceiveMessage", "System", "Connected to Flight Status Hub");
        await base.OnConnectedAsync();
    }
}
