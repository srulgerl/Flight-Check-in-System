// Web/Services/SignalRClient.cs
using Microsoft.AspNetCore.SignalR.Client;

namespace Web.Services
{
    public class SignalRClient
    {
        private HubConnection? _connection;

        public event Action<int, string>? OnFlightStatusChanged;

        public async Task StartAsync(string hubUrl)
        {
            _connection = new HubConnectionBuilder()
                .WithUrl(hubUrl)
                .WithAutomaticReconnect()
                .Build();

            _connection.On<int, string>("FlightStatusChanged", (flightId, status) =>
            {
                OnFlightStatusChanged?.Invoke(flightId, status);
            });

            await _connection.StartAsync();
        }

        public async Task StopAsync()
        {
            if (_connection != null)
            {
                await _connection.StopAsync();
                await _connection.DisposeAsync();
            }
        }
    }
}
