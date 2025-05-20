using Data.Models;
using Microsoft.AspNetCore.SignalR;

namespace Server.Hubs
{
    public class FlightStatusHub : Hub
    {
        public async Task UpdateFlightStatus(string flightNumber, FlightStatus status)
        {
            await Clients.All.SendAsync("ReceiveFlightStatusUpdate", flightNumber, status);
        }

        public async Task UpdatePassengerCount(string flightNumber, int count)
        {
            await Clients.All.SendAsync("ReceivePassengerCountUpdate", flightNumber, count);
        }

        public async Task BroadcastFlightUpdates(Flight flight)
        {
            await Clients.All.SendAsync("ReceiveFlightUpdate", flight);
        }
    }
}