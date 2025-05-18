using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Hubs
{
    public class FlightStatusHub: Hub
    {
        public async Task UpdateFlightStatus(int flightId, string newStatus)
        {
            // Notify all clients about the flight status update
            await Clients.All.SendAsync("FlightStatusChanged", flightId, newStatus);
        }
    }
}
