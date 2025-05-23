// File: Serverr/Hubs/FlightStatusHub.cs
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Text.Json;

namespace Serverr.Hubs
{
    public class FlightStatusHub : Hub
    {
        private readonly ILogger<FlightStatusHub> _logger;

        public FlightStatusHub(ILogger<FlightStatusHub> logger)
        {
            _logger = logger;
        }

        public async Task BroadcastFlightStatus(string flightId, string newStatus)
        {
            var payload = JsonSerializer.Serialize(new
            {
                FlightId = flightId,
                Status = newStatus
            });

            _logger.LogInformation("📡 Broadcasting flight {FlightId} status: {Status}", flightId, newStatus);
            await Clients.All.SendAsync("ReceiveFlightStatus", payload);
        }
    }
}
