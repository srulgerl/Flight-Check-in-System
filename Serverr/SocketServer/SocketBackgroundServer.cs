using Microsoft.Extensions.Hosting;
using Server.SocketServer;

namespace Server.SocketServer
{
    public class SocketBackgroundService : BackgroundService
    {
        private readonly CheckInSocketServer _socketServer;

        public SocketBackgroundService(CheckInSocketServer socketServer)
        {
            _socketServer = socketServer;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _socketServer.StartAsync(stoppingToken);
        }
    }
}
